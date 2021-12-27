using System;
using System.ComponentModel.DataAnnotations;
using Api.Application.Dtos.Event;
using Api.Application.Dtos.Speaker;

namespace Api.Application.Dtos.SocialMedia
{
    public class SocialMediaUpdateDto
    {
        public Guid Id { get; set; }

        [Display(Name = "Rede Social"),
         Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string SocialMedia { get; set; }

        public string UrlSocialMedia { get; set; }

        public Guid? EventId { get; set; }
        public EventDto Event { get; set; }

        public Guid? SpeakerId { get; set; }
        public SpeakerDto Speaker { get; set; }
    }
}

