using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class SocialMediaEntity : BaseEntities
    {
        public string SocialMedia { get; set; }

        public string UrlSocialMedia { get; set; }

        public Guid? EventId { get; set; }
        public EventEntity Event { get; set; }

        public Guid? SpeakerId { get; set; }
        public SpeakerEntity Speaker { get; set; }
    }
}

