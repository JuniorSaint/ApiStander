using System;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface ISocialMediaRepository : IRepository<SocialMediaEntity>
    {
        Task<SocialMediaEntity> GetSocialMediaEventById(Guid idEvent, Guid idSocial);
        Task<SocialMediaEntity> GetSocialMediaSpeakerById(Guid idSpeaker, Guid idSocial);
        Task<IEnumerable<SocialMediaEntity>> GetAllByEvent(Guid idEvent);
        Task<IEnumerable<SocialMediaEntity>> GetAllBySpeaker(Guid idSpeaker);
        Task<IEnumerable<SocialMediaEntity>> SaveSocialMediaAsync(IEnumerable<SocialMediaEntity> socialMedias, Guid idSpeaker);
    }
}

