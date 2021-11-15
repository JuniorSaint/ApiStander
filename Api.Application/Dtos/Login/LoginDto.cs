using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Application.Dtos.Login
{
    public class LoginDto
    {
        [Display(Name = "e-mail"),
         Required(ErrorMessage = "O campo {0} é obrigatório para Login"),
         EmailAddress(ErrorMessage = "campo {0} em formato inválido."),
         StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres."),
         RegularExpression(@"[a-z A-Z 0-9 _ \-\.]+[@]+[a-z]+[\.][a-z]{2,3}", ErrorMessage = "Campo email com formato inválido")]
        public string Email { get; set; }

        [Display(Name = "senha"),
         Required(ErrorMessage = "O campo {0} é obrigatório para Login")]
        public string Password { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

