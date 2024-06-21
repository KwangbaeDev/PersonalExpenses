using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Core.Request;

namespace Infrastructure.Services;

public class LoginService : ILoginService
{
    private readonly ILoginRepository _loginRepository;

    public LoginService(ILoginRepository loginRepository)
    {
        _loginRepository = loginRepository;
    }

    public async Task<DatosUsuarioDTO> AuthUser(CreateLoginModel model)
    {
        return await _loginRepository.AuthUser(model);
    }
}