using System.ComponentModel.DataAnnotations;

namespace DIO.Cursos.Models.Usuarios
{
    public class RegistroViewModelInput
    {
        public string Login { get; set; }
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatório")]
        public string Senha { get; set; }
    }
}
