using System;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class SpeakerRepository : BaseRepository<SpeakerEntity>, ISpeakerRepository

    {
        private DbSet<SpeakerEntity> _dataset;

        public SpeakerRepository(ApplicationDbContext contex) : base(contex)
        {
            _dataset = contex.Set<SpeakerEntity>();
        }

        public async Task<PageList<SpeakerEntity>> GetEventByTermAsync(PageParams pageParams)
        {
            IQueryable<SpeakerEntity> query = _dataset.AsNoTracking()
                         .Where(e => (
                                        e.SpeakerName.ToLower().Contains(pageParams.term.ToLower()) ||
                                        e.SpeakerEmail.ToLower().Contains(pageParams.term.ToLower()) ||
                                        e.MiniResume.ToLower().Contains(pageParams.term.ToLower())
                                      )
                                )
                         .OrderBy(e => e.SpeakerName);

            return await PageList<SpeakerEntity>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public async Task<SpeakerEntity> SelectByICompletedAsync(Guid id)
        {
            try
            {
                var result = await _dataset.AsNoTracking().Include(x => x.SocialMedias).SingleOrDefaultAsync(p => p.Id.Equals(id));

                if (result is null)
                {
                    throw new Exception($"O item com o Id {id} não foi encontrado");
                }
                return result;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException($"Erro ao localizar item com o Id {id}", e.Message);
            }
        }
    }
}

