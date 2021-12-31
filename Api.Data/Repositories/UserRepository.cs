using System;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLoginAsync(string email, string password)
        {
            try
            {
                return await _dataset.FirstOrDefaultAsync(u => u.UserEmail.ToLower().Equals(email.ToLower()) && u.Password.Equals(password) && u.IsActive.Equals(true));
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("erro ao localizar usuário", ex);
            }
        }

        public async Task<UserEntity> GetByEmail(string email)
        {
            try
            {
                return await _dataset.FirstOrDefaultAsync(x => x.UserEmail.ToLower().Contains(email.ToLower()));
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("erro ao localizar usuário por email", ex);
            }
        }

        public async Task<PageList<UserEntity>> GetEventByTermAsync(PageParams pageParams)
        {
            IQueryable<UserEntity> query = _dataset.AsNoTracking()
                         .Where(e => (
                                        e.UserName.ToLower().Contains(pageParams.term.ToLower()) ||
                                        e.UserEmail.ToLower().Contains(pageParams.term.ToLower())
                                      )
                                )
                         .OrderBy(e => e.UserName);

            return await PageList<UserEntity>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }
    }
}

