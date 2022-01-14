using Api.Application.Dtos;
using Api.Application.Dtos.SocialMedia;

namespace Api.Application.Interfaces
{
    public interface ISocialMediaService
    {
        Task<IEnumerable<SocialMediaDto>> SaveSocialMediasAsync(IEnumerable<SocialMediaDto> lot, Guid idEvent);
        Task<SocialMediaDto> GetSocialMediasBySpeakerBySocial(Guid idSpeaker, Guid idSocialMedia);
        Task<IEnumerable<SocialMediaDto>> GetSocialMediasBySpeaker(Guid idSpeaker);
        Task<bool> Delete(Guid id);    
    }
}

