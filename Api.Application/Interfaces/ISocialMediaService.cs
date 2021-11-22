using Api.Application.Dtos;
using Api.Application.Dtos.SocialMedia;

namespace Api.Application.Interfaces
{
    public interface ISocialMediaService
    {
        Task<SocialMediaDto> Post(SocialMediaCreateDto socialMedia);
        Task<SocialMediaDto> Put(SocialMediaUpdateDto socialMedia);
        Task<bool> Delete(Guid id);
        Task<SocialMediaDto> Get(Guid id);
        Task<IEnumerable<SocialMediaDto>> GetAll();
        Task<IEnumerable<SocialMediaDto>> GetAllPage(int skip, int take);
    }
}

