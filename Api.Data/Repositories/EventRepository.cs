﻿using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class EventRepository : BaseRepository<EventEntity>, IEventRepository
    {
        private DbSet<EventEntity> _dataset;

        public EventRepository(ApplicationDbContext context) : base(context)
        {
            _dataset = context.Set<EventEntity>();
        }

        public async Task<IEnumerable<EventEntity>> GetAllEventByThemeAsync(string theme)
        {
            try
            {
                return await _dataset.Where(x => x.Theme == theme).Include(x => x.Speakers).ToListAsync();
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public async Task<EventEntity> GetEventByIdAsync(Guid eventId)
        {
            try
            {
                return await _dataset.Include(x => x.Speakers).FirstOrDefaultAsync(x => x.Id.Equals(eventId));
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}
