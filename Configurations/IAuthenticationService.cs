using DIO.Cursos.Models.Usuarios;

namespace DIO.Cursos.Configurations
{
    public interface IAuthenticationService
    {
        string GerarToken(UsuarioViewModelOutput usuarioViewModelOutput);
    }
}
