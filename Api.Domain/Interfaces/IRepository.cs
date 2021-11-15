using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntities
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectByIdAsync(Guid id);
        Task<IEnumerable<T>> SelectAllAsync();
        Task<IEnumerable<T>> SelectAllPageAsync(int skip, int take);
        Task<bool> ExistAsync(Guid id);
    }
}
