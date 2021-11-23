using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Domain.Entities
{
    public class SpeakerEntity : BaseEntities
    {

        public string SpeakerName { get; set; }
        public string MiniResume { get; set; }
        public string SpeakerImage { get; set; }
        public string SpeakerPhone { get; set; }
        public string SpeakerEmail { get; set; }
        public DateTime Birthday { get; set; }
        public IEnumerable<SocialMediaEntity> SocialMedias { get; set; }
        public IEnumerable<SpeakerEventEntity> SpeakerEvents { get; set; }

        [NotMapped]
        public int Age { get; set; }
    }
}

