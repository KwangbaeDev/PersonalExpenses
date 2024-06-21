using Core.Entities;
using Core.Models;
using Core.Request;

namespace Core.Interfaces.Services;

public interface IJwtProvider
{
    string Generate(DatosUsuarioDTO user);
}