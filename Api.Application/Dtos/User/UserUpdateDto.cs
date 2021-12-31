using System;
using System.ComponentModel.DataAnnotations;


namespace Api.Application.Dtos.User
{
    public class UserUpdateDto
    {
        public Guid Id { get; set; }

        [Display(Name = "Nome do usuário"),
         Required(ErrorMessage = "O campo {0} é campo obrigatório"),
         MaxLength(90, ErrorMessage = "Número máximo de caractes {1} ")]
        public string UserName { get; set; }

        [Display(Name = "e-mail"),
         Required(ErrorMessage = "O campo {0} é campo obrigatório"),
         RegularExpression(@"[a-z A-Z 0-9 _ \-\.]+[@]+[a-z]+[\.][a-z]{2,3}", ErrorMessage = "Campo {0} com formato inválido"),
         MaxLength(100, ErrorMessage = "Número máximo de caractes {1} ")]
        public string UserEmail { get; set; }

        [Display(Name = "senha do usuário"),
         Required(ErrorMessage = "O campo {0} é campo obrigatório"),
         MinLength(6, ErrorMessage = "Quantidade mínima de  caracteres {1}")]
        public string Password { get; set; }

        [Display(Name = "usuário ativo"),
         Required(ErrorMessage = "O campo {0} é campo obrigatório")]
        public bool IsActive { get; set; }

        [Display(Name = "Tipo de usuário"),
         Required(ErrorMessage = "O campo {0} é campo obrigatório")]
        public string UserType { get; set; }


        public string UserImage { get; set; }

        public string Title { get; set; }
    }
}

