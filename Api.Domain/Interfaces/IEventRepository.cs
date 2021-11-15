using System;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IEventRepository : IRepository<EventEntity>
    {
        Task<IEnumerable<EventEntity>> GetAllEventByThemeAsync(string theme);
        Task<EventEntity> GetEventByIdAsync(Guid eventId);
    }
}

