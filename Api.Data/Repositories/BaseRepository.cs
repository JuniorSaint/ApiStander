using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
                if (result == null) throw new Exception($"O Id {id} não foi encontrado");

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException($" Não foi possível excluir com o Id {id}", e.Message);
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
            catch (ArgumentException e)
            {
                throw new ArgumentException($"Erro ao salvar arquivo", e.Message);
            }
            return item;
        }

        public async Task<T> SelectByIdAsync(Guid id)
        {
            try
            {
                var result = await _dataset.AsNoTracking().SingleOrDefaultAsync(p => p.Id.Equals(id));

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

        public async Task<IEnumerable<T>> SelectAllAsync()
        {
            try
            {
                return await _dataset.AsNoTracking().ToListAsync();
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Erro ao localizar os itens", e.Message);
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                if (result == null) throw new Exception($"Erro ao atualizar/localizar o item com o Id {item.Id}");

                item.UpdatedAt = DateTime.UtcNow;
                item.CreatedAt = result.CreatedAt;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException($"Erro ao atualizar o item com o Id {item.Id}", e.Message);
            }
            return item;
        }
    }
}
