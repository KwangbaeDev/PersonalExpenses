using Core.Models;
using Core.Request;

namespace Core.Interfaces.Services;

public interface ILoginService
{
    Task<DatosUsuarioDTO> AuthUser(CreateLoginModel model);    
}