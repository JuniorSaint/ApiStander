using System;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{

    public interface ILotRepository : IRepository<LotEntity>
    {
        Task<LotEntity> GetLotById(Guid id, Guid idEvent);
        Task<IEnumerable<LotEntity>> GetLotsByEventAsync(Guid idEvent);
        Task<IEnumerable<LotEntity>> SaveLotsAsync(IEnumerable<LotEntity> lot, Guid idEvent);
    }
}

