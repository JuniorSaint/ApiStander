using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Application.Dtos.Login
{
    public class LoginDto
    {
        [Display(Name = "e-mail"),
         Required(ErrorMessage = "O campo {0} é obrigatório para Login"),
         StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }

        [Display(Name = "senha"),
         Required(ErrorMessage = "O campo {0} é obrigatório para Login")]
        public string Password { get; set; }
    }
}

