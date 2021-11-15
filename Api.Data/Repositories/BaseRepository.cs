using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Api.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntities
    {
        protected readonly ApplicationDbContext _context;
        private DbSet<T> _dataset;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.AsNoTracking().SingleOrDefaultAsync(p => p.Id.Equals(id));
                if (result == null) return false;

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }
                item.CreatedAt = DateTime.UtcNow;
                _dataset.Add(item);

                await _context.SaveChangesAsync();

            }
            catch (ArgumentException)
            {
                throw;
            }
            return item;
        }

        public async Task<T> SelectByIdAsync(Guid id)
        {
            try
            {
                return await _dataset.AsNoTracking().SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> SelectAllAsync()
        {
            try
            {
                return await _dataset.AsNoTracking().ToListAsync();
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                if (result == null) return null;

                item.UpdatedAt = DateTime.UtcNow;
                item.CreatedAt = result.CreatedAt;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return item;
        }

        public async Task<IEnumerable<T>> SelectAllPageAsync(int skip, int take)
        {
            try
            {
                var count = _dataset.Count();
                return await _dataset.AsNoTracking().Skip(skip > 0 ? ((skip - 1) * take) : 0).Take(take).ToListAsync();
            }
            catch (ArgumentException)
            {
                throw;
            }
        }
    }
}
