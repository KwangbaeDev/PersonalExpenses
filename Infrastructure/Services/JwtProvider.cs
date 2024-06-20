using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Entities;
using Core.Interfaces.Services;
using Core.Models;
using Core.Options;
using Core.Request;
using Infrastructure.Repositories;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services;

public class JwtProvider : IJwtProvider 
{
    private readonly JwtOptions _jwtSettings;
    private readonly IPasswordHasher<User> _passwordHasher;

    public JwtProvider(IOptions<JwtOptions> jwtSettings, IPasswordHasher<User> passwordHasher)
    {
        _jwtSettings = jwtSettings.Value;
        _passwordHasher = passwordHasher;
    }

    public async Task<DatosUsuarioDTO> GetToken(CreateLoginModel model)
    {
        DatosUsuarioDTO datosUsuarioDTO= new DatosUsuarioDTO();

        var createLogin = model.Adapt<User>();

        createLogin.Password = _passwordHasher.HashPassword(createLogin, model.Password);

        var user = model.Adapt<User>();

        var resultado = _passwordHasher.VerifyHashedPassword(user, user.Password, createLogin.Password);

        if (resultado == PasswordVerificationResult.Success)
        {
            datosUsuarioDTO.EstaAutenticado = true;
            JwtSecurityToken jwtSecurityToken = CreateJwtToken(user);
            datosUsuarioDTO.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            datosUsuarioDTO.Email =  user.Email;
            datosUsuarioDTO.Name = user.Name;
        }
        return datosUsuarioDTO;

    
    }

    private JwtSecurityToken CreateJwtToken(User user)
    {
        var roles = new List<string> { "User" };
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim(ClaimTypes.Role, role));
        }
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Name),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id.ToString())
        }
        .Union(roleClaims);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken =  new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials
            );
        return jwtSecurityToken;
    }
}
