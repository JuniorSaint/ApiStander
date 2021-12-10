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

        public async Task<LotEntity> GetLotById(Guid id, Guid idEvent)
        {
            var result = await _dataset.AsNoTracking().Where(x => x.Id == id && x.EventId == idEvent).SingleOrDefaultAsync();
            return result;
        }

        public async Task<IEnumerable<LotEntity>> GetLotsByEventAsync(Guid idEvent)
        {
            var result = await _dataset.AsNoTracking().Where(x => x.EventId == idEvent).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<LotEntity>> SaveLotsAsync(IEnumerable<LotEntity> models, Guid idEvent)
        {
            try
            {
                foreach (var model in models)
                {
                    if (model.Id == Guid.Empty)
                    {
                        await InsertAsync(model);
                    }
                    else
                    {
                        var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(model.Id));
                        if (result == null) throw new Exception($"Erro ao atualizar/localizar o item com o Id {model.Id}");


                        _context.Entry(result).CurrentValues.SetValues(model);
                        await _context.SaveChangesAsync();
                    }
                }
             return   await GetLotsByEventAsync(idEvent);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

