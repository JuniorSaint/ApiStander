using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Application.Dtos.Speaker
{
    public class SpeakerUpdateDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Id { get; set; }

        [Display(Name = "Nome do orador"),
         Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string SpeakerName { get; set; }

        public string MiniResume { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$",
             ErrorMessage = "Não é uma imagem válida. (gif, jpg, jpeg, bmp ou png)")]
        public string SpeakerImage { get; set; }

        [Phone]
        public string SpeakerPhone { get; set; }

        [Display(Name = "e-mail"),
         Required(ErrorMessage = "Enviar para é obrigatório"),
         RegularExpression(@"[a-z A-Z 0-9 _ \-\.]+[@]+[a-z]+[\.][a-z]{2,3}", ErrorMessage = "Campo email com formato inválido")]
        public string SpeakerEmail { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Id do Usuário")]
        public Guid IdUser { get; set; }
    }
}

