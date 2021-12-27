using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Application.Dtos.Speaker
{
    public class SpeakerUpdateDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid Id { get; set; }

        [Display(Name = "Nome do palestrante"),
         Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string SpeakerName { get; set; }

        public string MiniResume { get; set; }

        public string SpeakerImage { get; set; }

        [Phone]
        public string SpeakerPhone { get; set; }

        public DateTime? Birthday { get; set; }

        [Required(ErrorMessage = "Enviar para é obrigatório")]    
        public string SpeakerEmail { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[Display(Name = "Id do Usuário")]
        //public Guid IdUser { get; set; }
    }
}

