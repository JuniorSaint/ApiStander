using System;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{

    public interface ILotRepository : IRepository<LotEntity>
    {
        Task<LotEntity> GetLotByEventAndLotAsync(Guid idEvent, Guid id);
        Task<IEnumerable<LotEntity>> GetAllLotCompleteAsync();
        Task<IEnumerable<LotEntity>> GetLotByEventAsync(Guid idEvent);
        Task<LotEntity> UpdateLotAsync(Guid idEvent, LotEntity items);
    }
}

