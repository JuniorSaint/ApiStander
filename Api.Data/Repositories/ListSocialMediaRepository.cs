using System;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class ListSocialMediaRepository : IListSocialMediaRepository
    {
        private DbSet<ListSocialMediaEntity> _dataset;

        public ListSocialMediaRepository(ApplicationDbContext context) 
        {
            _dataset = context.Set<ListSocialMediaEntity>();
        }

        public async Task<IEnumerable<ListSocialMediaEntity>> GetAllListSocialMedia()
        {
            try
            {
                return await _dataset.AsNoTracking().OrderBy(x => x.SocialMediaName).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível encontrar nomes de redes sociais", ex);
            }
        }
    }
}

