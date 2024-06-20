using Core.Models;
using Core.Request;

namespace Core.Interfaces.Services;

public interface IJwtProvider
{
    Task<DatosUsuarioDTO> GetToken(CreateLoginModel model);
}