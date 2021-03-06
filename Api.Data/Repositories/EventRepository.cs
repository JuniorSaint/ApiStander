using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Pagination;
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

        public async Task<PageList<EventEntity>> GetEventByTermAsync( PageParams pageParams)
        {
            IQueryable<EventEntity> query = _dataset.AsNoTracking()
                         .Where(e => (
                                        e.Theme.ToLower().Contains(pageParams.term.ToLower()) ||
                                        e.Local.ToLower().Contains(pageParams.term.ToLower())
                                      )
                                )
                         .OrderBy(e => e.EventDate).OrderBy(e => e.EventDate);

            return await PageList<EventEntity>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }


        public async Task<EventEntity> GetEventByIdAsync(Guid eventId)
        {
            try
            {
                return await _dataset.Include(x => x.Lots).FirstOrDefaultAsync(x => x.Id.Equals(eventId));
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public async Task<EventEntity> GetAllCompleteAsync(Guid id)
        {
            try
            {
                return await _dataset.Include(x => x.Lots).FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                throw new Exception("não há itens a serem listados");
            }
        }

    }
}

