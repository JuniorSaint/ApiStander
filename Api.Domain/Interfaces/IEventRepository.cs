using System;
using Api.Domain.Entities;
using Api.Domain.Utilities;

namespace Api.Domain.Interfaces
{
    public interface IEventRepository : IRepository<EventEntity>
    {
        Task<PageList<EventEntity>> GetEventByTermAsync(PageParams pageParams);
        Task<EventEntity> GetEventByIdAsync(Guid eventId);
        Task<EventEntity> GetAllCompleteAsync(Guid id);
        
    }
}

