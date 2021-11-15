using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class SpeakerEntity : BaseEntities
    {

        public string SpeakerName { get; set; }
        public string MiniResume { get; set; }
        public string SpeakerImage { get; set; }
        public string SpeakerPhone { get; set; }
        public string SpeakerEmail { get; set; }
        public Guid IdUser { get; set; }
        public UserEntity User { get; set; }
        public IEnumerable<SocialMediaEntity> SocialMedias { get; set; }
        public IEnumerable<SpeakerEventEntity> SpeakerEvents { get; set; }
    }
}

