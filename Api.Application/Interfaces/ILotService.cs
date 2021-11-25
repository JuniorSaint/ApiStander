using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Dtos;
using Api.Application.Dtos.Lot;

namespace Api.Application.Interfaces
{
    public interface ILotService
    {
        Task<LotDto> Post(LotCreateDto lot);
        Task<LotDto> Put(LotUpdateDto lot);
        Task<bool> Delete(Guid id);
        Task<LotDto> Get(Guid id);
        Task<IEnumerable<LotDto>> GetLotByEventAsync(Guid idEvent);
    }
}

