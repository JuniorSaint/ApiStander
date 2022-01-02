using System;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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
                var result =  await _dataset.FirstOrDefaultAsync(u => u.UserEmail.ToLower().Equals(email.ToLower()) && u.IsActive.Equals(true));

                if (result != null)
                {
                    var validResult = await ValidUpdatePassword(password, result.Password, result);
                    return validResult ? result : null;
                }
                else
                {
                    return null;
                }
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("erro ao localizar usuário", ex);
            }
        }

        // to valid the password cripytography
        private async Task<bool> ValidUpdatePassword(string password, string resultPassword, UserEntity user)
        {
            var passwordHasher = new PasswordHasher<string>();
            var status = passwordHasher.VerifyHashedPassword(password, resultPassword, password);
            switch (status)
            {
                case PasswordVerificationResult.Failed: return false;
                case PasswordVerificationResult.Success: return true;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    await UpdateAsync(user); return true;
                default: throw new InvalidOperationException();
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

