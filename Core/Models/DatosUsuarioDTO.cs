namespace Core.Models;

public class DatosUsuarioDTO
{
    public string Mensaje { get; set; } = string.Empty;
    public bool EstaAutenticado { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<string> Roles { get; set; }
    public string Token { get; set; } = string.Empty;
}