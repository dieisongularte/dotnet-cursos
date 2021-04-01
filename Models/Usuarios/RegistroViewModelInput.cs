using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
