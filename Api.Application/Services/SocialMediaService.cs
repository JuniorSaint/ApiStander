

using Api.Application.Dtos.SocialMedia;
using Api.Application.Interfaces;

namespace Api.Application.Services
{
    public class SocialMediaService : ISocialMediaService
    {
        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<SocialMediaDto> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SocialMediaDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SocialMediaDto>> GetAllPage(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public Task<SocialMediaDto> Post(SocialMediaCreateDto socialMedia)
        {
            throw new NotImplementedException();
        }

        public Task<SocialMediaDto> Put(SocialMediaUpdateDto socialMedia)
        {
            throw new NotImplementedException();
        }
    }
}

