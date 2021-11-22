using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class EventEntity : BaseEntities
    {
        public string Local { get; set; }

        public DateTime EventDate { get; set; }

        public TimeSpan EventTime { get; set; }

        public string Theme { get; set; }

        public int PeopleAmount { get; set; }

        public string EventImage { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public IEnumerable<LotEntity> Lots { get; set; }
        public IEnumerable<SocialMediaEntity> SocialMedias { get; set; }
        public IEnumerable<SpeakerEventEntity> Speakers { get; set; }
    }
}

