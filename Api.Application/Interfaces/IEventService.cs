using Api.Application.Dtos;
using Api.Application.Dtos.Event;
using Api.Domain.Pagination;

namespace Api.Application.Interfaces
{
    public interface IEventService
    {
        Task<EventDto> GetEventById(Guid eventId);
        Task<IEnumerable<EventDto>> GetAll();
        Task<EventDto> Post(EventCreateDto usuario);
        Task<EventDto> Put(EventUpdateDto usuario);
        Task<bool> Delete(Guid id);
        Task<PageList<EventDto>> GetAllByTerm(PageParams pageParams);
        Task<EventDto> GetByIdCompletInformation(Guid id);
        Task<EventDto> PostUpload(EventUpdateDto events, Guid id);
    }
}