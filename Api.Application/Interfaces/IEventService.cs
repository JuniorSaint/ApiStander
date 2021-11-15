using Api.Application.Dtos.Event;

namespace Api.Application.Interfaces
{
    public interface IEventService
    {
        Task<EventDto> Get(Guid id);
        Task<IEnumerable<EventDto>> GetAll();
        Task<bool> Delete(Guid id);
        Task<EventDto> Put(EventUpdateDto evento);
        Task<EventDto> Post(EventCreateDto evento);
        Task<EventDto> PostUpload(EventUpdateDto events, Guid id);
        Task<IEnumerable<EventDto>> GetAllPage(int skip, int take);
        Task<EventDto> GetAllByTheme(string theme);
        Task<EventDto> GetEventById(Guid eventId);
    }
}