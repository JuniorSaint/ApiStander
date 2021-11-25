using System;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces
{

    public interface ILotRepository : IRepository<LotEntity>
    {
        Task<IEnumerable<LotEntity>> GetLotByEventAsync(Guid idEvent);
        Task<LotEntity> UpdateLotAsync(LotEntity lot);
    }
}

