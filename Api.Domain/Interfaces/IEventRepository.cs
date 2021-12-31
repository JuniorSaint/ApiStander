using System;
using Api.Domain.Entities;
using Api.Domain.Pagination;

namespace Api.Domain.Interfaces
{
    public interface IEventRepository : IRepository<EventEntity>
    {
        Task<EventEntity> GetEventByIdAsync(Guid eventId);
        Task<EventEntity> GetAllCompleteAsync(Guid id);
        Task<PageList<EventEntity>> GetEventByTermAsync(PageParams pageParams);
    }
}

