using Core.Models;
using Core.Request;

namespace Core.Interfaces.Repositories;

public interface ILoginRepository
{
    Task<DatosUsuarioDTO> AuthUser(CreateLoginModel model);
}