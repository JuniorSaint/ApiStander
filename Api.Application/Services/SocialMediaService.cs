

using Api.Application.Dtos.SocialMedia;
using Api.Application.Interfaces;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using AutoMapper;

namespace Api.Application.Services
{
    public class SocialMediaService : ISocialMediaService
    {
        private ISocialMediaRepository _repository;
        private readonly IMapper _mapper;

        public SocialMediaService(ISocialMediaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
           

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<SocialMediaDto> GetSocialMediasBySpeakerBySocial(Guid idSpeaker, Guid idSocialMedia)
        {
            var result = await _repository.GetSocialMediaSpeakerById(idSpeaker, idSocialMedia);
            return _mapper.Map<SocialMediaDto>(result);
        }

        public async Task<IEnumerable<SocialMediaDto>> GetSocialMediasBySpeaker(Guid idSpeaker)
        {
            var result = await _repository.GetAllBySpeaker(idSpeaker);
            return _mapper.Map<IEnumerable<SocialMediaDto>>(result);
        }

        public async Task<IEnumerable<SocialMediaDto>> SaveSocialMediasAsync(IEnumerable<SocialMediaDto> socialMedia, Guid idSpeaker)
        {
            var entity = _mapper.Map<IEnumerable<SocialMediaEntity>>(socialMedia);
            var result = await _repository.SaveSocialMediaAsync(entity, idSpeaker);
            return _mapper.Map<IEnumerable<SocialMediaDto>>(result);
        }
    }
}

