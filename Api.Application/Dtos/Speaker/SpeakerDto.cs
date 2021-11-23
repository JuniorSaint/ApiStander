using Api.Application.Dtos.Event;
using Api.Application.Dtos.SocialMedia;
using Api.Data;
using Microsoft.IdentityModel.Tokens;

namespace Api.Application.Dtos.Speaker
{
    public class SpeakerDto
    {
        public Guid? Id { get; set; }
        public string SpeakerName { get; set; }
        public string MiniResume { get; set; }
        public string SpeakerImage { get; set; }
        public string SpeakerPhone { get; set; }
        public string SpeakerEmail { get; set; }
        public IEnumerable<SocialMediaDto> SocialMedias { get; set; }
        public IEnumerable<EventDto> Events { get; set; }
        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; }
        public DateTime Birthday { get; set; }
        private int _age { get; set; }
        public int Age
        {
            get { return _age; }
            set { _age = new CalcAge(Birthday).AgeAlready(); }
        }
    }
}
