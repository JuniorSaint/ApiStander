using System;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Api.Data.Repositories
{
    public class SocialMediaRepository : BaseRepository<SocialMediaEntity>, ISocialMediaRepository
    {
        private DbSet<SocialMediaEntity> _dataset;

        public SocialMediaRepository(ApplicationDbContext context) : base(context)
        {
            _dataset = context.Set<SocialMediaEntity>();
        }



        public async Task<IEnumerable<SocialMediaEntity>> GetAllByEvent(Guid idEvent)
        {
            try
            {
                return await _dataset.Where(x => x.EventId == idEvent).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Redes sociais por eventos não encontrado", ex);
            }

        }

        public async Task<IEnumerable<SocialMediaEntity>> GetAllBySpeaker(Guid idSpeaker)
        {
            try
            {
                return await _dataset.Where(x => x.SpeakerId == idSpeaker).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Redes sociais por palestrante não encontrado", ex);
            }
        }

        public async Task<SocialMediaEntity> GetSocialMediaEventById(Guid idEvent, Guid idSocial)
        {
            try
            {
                return await _dataset.FirstOrDefaultAsync(x => x.Id == idSocial && x.EventId == idEvent);
            }
            catch (Exception ex)
            {
                throw new Exception("Rede social por evento não encontrado", ex);
            }
        }

        public async Task<SocialMediaEntity> GetSocialMediaSpeakerById(Guid idSpeaker, Guid idSocialMedia)
        {
            try
            {
                return await _dataset.FirstOrDefaultAsync(x => x.SpeakerId == idSpeaker && x.Id == idSocialMedia);
            }
            catch (Exception ex)
            {
                throw new Exception("Rede social por palestrante não encontrado", ex);
            }
        }

        public async Task<IEnumerable<SocialMediaEntity>> SaveSocialMediaAsync(IEnumerable<SocialMediaEntity> models, Guid idSpeaker)
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
                return await GetAllBySpeaker(idSpeaker);
            }
            catch (Exception ex)
            {
                  throw new Exception(ex.Message);
            }
        }        

    }
}

