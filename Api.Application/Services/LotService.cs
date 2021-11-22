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

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<LotDto> Get(Guid id)
        {
            var entity = await _repository.SelectByIdAsync(id);
            return _mapper.Map<LotDto>(entity);
        }

        public async Task<IEnumerable<LotDto>> GetLotByEventAsync(Guid idEvent)
        {
            var listEntity = await _repository.GetLotByEventAsync(idEvent);
            return _mapper.Map<IEnumerable<LotDto>>(listEntity);
        }

        public async Task<LotDto> Post(LotCreateDto lote)
        {
            var entity = _mapper.Map<LotEntity>(lote);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<LotDto>(result);
        }

        public async Task<LotDto> Put(LotUpdateDto lot)
        {
            var entity = _mapper.Map<LotEntity>(lot);
            var result = await _repository.UpdateLotAsync(entity);
            return _mapper.Map<LotDto>(result);
        }

        public async Task<IEnumerable<LotDto>> GetAll()
        {
            var listEntity = await _repository.SelectAllAsync();
            return _mapper.Map<IEnumerable<LotDto>>(listEntity);
        }

        public async Task<IEnumerable<LotDto>> GetAllLotCompleteAsync()
        {
            var listEntity = await _repository.GetAllLotCompleteAsync();
            return _mapper.Map<IEnumerable<LotDto>>(listEntity);
        }

        Task<IEnumerable<LotDto>> ILotService.GetLotByEventLotAsync(Guid eventId, Guid loteId)
        {
            throw new NotImplementedException();
        }
    }
}

