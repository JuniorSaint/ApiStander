using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Application.Dtos.User
{
    public class UserPasswordUpdateDto
    {
        public Guid? Id { get; set; }

        [Display(Name = "e-mail"),
         Required(ErrorMessage = "O campo {0} é campo obrigatório"),
         RegularExpression(@"[a-z A-Z 0-9 _ \-\.]+[@]+[a-z]+[\.][a-z]{2,3}", ErrorMessage = "Campo {0} com formato inválido"),
         MaxLength(100, ErrorMessage = "Número máximo de caractes {1} ")]
        public string Email { get; set; }

        [Display(Name = "senha do usuário"),
         Required(ErrorMessage = "O campo {0} é campo obrigatório"),
         MinLength(6, ErrorMessage = "Quantidade mínima de  caracteres {1}")]
        public string Password { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

