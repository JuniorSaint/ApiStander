
using Api.Application.Dtos.Lot;
using Api.Application.Interfaces;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using AutoMapper;

namespace Api.Application.Services
{
    public class LotService : ILotService
    {

        private ILotRepository _repository;
        private readonly IMapper _mapper;

        public LotService(ILotRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<LotDto>> SaveLotsAsync(IEnumerable<LotUpdateDto> lot, Guid idEvent)
        {
            var entity = _mapper.Map<IEnumerable<LotEntity>>(lot);
            var result = await _repository.SaveLotsAsync(entity, idEvent);
            return _mapper.Map<IEnumerable<LotDto>>(result);
        }

        public async Task<LotDto> GetLotByIdAsync(Guid id, Guid idEvent)
        {
            var result = await _repository.GetLotById(id, idEvent);
            return _mapper.Map<LotDto>(result);
        }

        public async Task<IEnumerable<LotDto>> GetLotsByEventAsync(Guid idEvent)
        {
            var result = await _repository.GetLotsByEventAsync(idEvent);
            return _mapper.Map<IEnumerable<LotDto>>(result);
        }
    }
}

