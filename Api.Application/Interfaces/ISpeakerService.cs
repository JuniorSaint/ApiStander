using Api.Application.Dtos;
using Api.Application.Dtos.Speaker;

namespace Api.Application.Interfaces
{
    public interface ISpeakerService
    {
        Task<SpeakerDto> Post(SpeakerCreateDto speaker);
        Task<SpeakerDto> Put(SpeakerUpdateDto speaker);
        Task<bool> Delete(Guid id);
        Task<SpeakerDto> Get(Guid id);
        Task<IEnumerable<SpeakerDto>> GetAll();
        Task<IEnumerable<SpeakerDto>> GetAllPage(int skip, int take);
    }
}

