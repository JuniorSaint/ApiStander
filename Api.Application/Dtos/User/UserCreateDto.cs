using System;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Enum;

namespace Api.Application.Dtos.User
{
    public class UserCreateDto
    {
        [Display(Name = "Nome do usuário"),
         Required(ErrorMessage = "O campo {0} é campo obrigatório"),
         MaxLength(90, ErrorMessage = "Número máximo de caractes {1} ")]
        public string UserName { get; set; }

        [Display(Name = "e-mail"),
         Required(ErrorMessage = "O campo {0} é campo obrigatório"),
         RegularExpression(@"[a-z A-Z 0-9 _ \-\.]+[@]+[a-z]+[\.][a-z]{2,3}", ErrorMessage = "Campo {0} com formato inválido"),
         MaxLength(100, ErrorMessage = "Número máximo de caractes {1} ")]
        public string Email { get; set; }

        [Display(Name = "senha do usuário"),
         Required(ErrorMessage = "O campo {0} é campo obrigatório"),
         MinLength(6, ErrorMessage = "Quantidade mínima de  caracteres {1}")]
        public string Password { get; set; }

        [Display(Name = "usuário ativo"),
         Required(ErrorMessage = "O campo {0} é campo obrigatório")]
        public IsActive IsActive { get; set; }

        [Display(Name = "Tipo de usuário"),
         Required(ErrorMessage = "O campo {0} é campo obrigatório")]
        public UserType UserType { get; set; }
    }
}

