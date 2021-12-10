using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Dtos;
using Api.Application.Dtos.Lot;

namespace Api.Application.Interfaces
{
    public interface ILotService
    {
        Task<IEnumerable<LotDto>> SaveLotsAsync(IEnumerable<LotUpdateDto> lot, Guid idEvent);
        Task<bool> DeleteAsync(Guid id);
        Task<LotDto> GetLotByIdAsync(Guid id, Guid idEvent);
        Task<IEnumerable<LotDto>> GetLotsByEventAsync(Guid idEvent);
    }
}

