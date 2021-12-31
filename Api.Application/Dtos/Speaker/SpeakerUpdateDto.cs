using System;
using System.ComponentModel.DataAnnotations;
using Api.Domain.Entities;

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

        public string SpeakerEmail { get; set; }

        public IEnumerable<SocialMediaEntity> SocialMedias { get; set; }

        public IEnumerable<SpeakerEventEntity> SpeakerEvents { get; set; }
    }
}

