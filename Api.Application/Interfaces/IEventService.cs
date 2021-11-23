using Api.Application.Dtos;
using Api.Application.Dtos.Event;

namespace Api.Application.Interfaces
{
    public interface IEventService
    {
        Task<EventDto> Post(EventCreateDto usuario);
        Task<EventDto> Put(EventUpdateDto usuario);
        Task<bool> Delete(Guid id);
        Task<EventDto> Get(Guid id);
        Task<IEnumerable<EventDto>> GetAll();
        Task<IEnumerable<EventDto>> GetAllPage(int skip, int take);
        Task<IEnumerable<EventDto>> GetAllComplete(Guid id);
        Task<EventDto> PostUpload(EventUpdateDto events, Guid id);
        Task<IEnumerable<EventDto>> GetAllByTheme(string theme);
        Task<EventDto> GetEventById(Guid eventId);
    }
}