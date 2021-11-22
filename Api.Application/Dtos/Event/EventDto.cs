using Api.Application.Dtos.Lot;
using Api.Application.Dtos.SocialMedia;
using Api.Application.Dtos.Speaker;

namespace Api.Application.Dtos.Event
{
    public class EventDto
    {
        public Guid Id { get; set; }

        public string Local { get; set; }

        public DateTime EventDate { get; set; }

        public TimeSpan EventTime { get; set; }

        public string Theme { get; set; }

        public int PeopleAmount { get; set; }

        public string EventImage { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public IEnumerable<LotDto> Lots { get; set; }
        public IEnumerable<SocialMediaDto> socialMedias { get; set; }
        public IEnumerable<SpeakerDto> Speakers { get; set; }

        public DateTime? CreatedAt { get; }

        public DateTime? UpdatedAt { get; }
    }
}

