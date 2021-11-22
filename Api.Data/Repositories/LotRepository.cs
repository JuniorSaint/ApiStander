using System;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class LotRepository : BaseRepository<LotEntity>, ILotRepository
    {
        private DbSet<LotEntity> _dataset;

        public LotRepository(ApplicationDbContext contex) : base(contex)
        {
            _dataset = contex.Set<LotEntity>();
        }

        public async Task<IEnumerable<LotEntity>> GetAllLotCompleteAsync()
        {
            try
            {
                return await _dataset.Include(l => l.Event).ToListAsync();
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public async Task<LotEntity> GetLotByEventAndLotAsync(Guid idEvent, Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(x => x.EventId == idEvent && x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<LotEntity>> GetLotByEventAsync(Guid idEvent)
        {
            try
            {
                return await _dataset.Where(x => x.EventId.Equals(idEvent)).ToListAsync();
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public async Task<LotEntity> UpdateLotAsync(LotEntity item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id == item.Id);
                if (result is null) return null;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

