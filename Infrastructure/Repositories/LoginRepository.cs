using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Models;
using Core.Request;
using Infrastructure.Context;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class LoginRepository : ILoginRepository
{
    private readonly PersonalExpensesContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;

    public LoginRepository(PersonalExpensesContext context, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task<DatosUsuarioDTO> AuthUser(CreateLoginModel model)
    {
        var verificUser = await _context.Users
                                            .Where(u => u.Email.ToLower() == model.Email.ToLower())
                                            .FirstOrDefaultAsync();
        if (verificUser == null)
        {
            throw new BusinessLogicException("Incorrect username or password");
        }

        var result = _passwordHasher.VerifyHashedPassword(verificUser, verificUser.Password, model.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            throw new BusinessLogicException("Incorrect username or password");
        }

        var datosUsuarioDTO = verificUser.Adapt<DatosUsuarioDTO>();
        return datosUsuarioDTO;
        
    }
}