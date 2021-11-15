using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Application.Dtos.Email
{
    public class SendEmailDto
    {
        [Required(ErrorMessage = "Enviar para é obrigatório")]
        [RegularExpression(@"[a-z A-Z 0-9 _ \-\.]+[@]+[a-z]+[\.][a-z]{2,3}", ErrorMessage = "Campo email com formato inválido")]
        public string SendTo { get; set; }

        [Required(ErrorMessage = "Enviar para é obrigatório")]
        public string Subject { get; set; }


        [Required(ErrorMessage = "O corpo da mensagem é obrigatório")]
        public string BodyEmail { get; set; }
    }
}

