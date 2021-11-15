using Api.Application.Dtos.Speaker;
using Api.Application.Interfaces;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using AutoMapper;

namespace Api.Application.Services
{
    public class SpeakerService : ISpeakerService
    {
        private ISpeakerRepository _repository;
        private readonly IMapper _mapper;

        public SpeakerService(ISpeakerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<SpeakerDto> Get(Guid id)
        {
            var entity = await _repository.SelectByIdAsync(id);
            return _mapper.Map<SpeakerDto>(entity);
        }

        public async Task<IEnumerable<SpeakerDto>> GetAll()
        {
            var listEntity = await _repository.SelectAllAsync();
            return _mapper.Map<IEnumerable<SpeakerDto>>(listEntity);
        }

        public async Task<SpeakerDto> Post(SpeakerCreateDto speaker)
        {
            var entity = _mapper.Map<SpeakerEntity>(speaker);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<SpeakerDto>(result);
        }

        public async Task<SpeakerDto> Put(SpeakerUpdateDto speaker)
        {
            var entity = _mapper.Map<SpeakerEntity>(speaker);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<SpeakerDto>(result);
        }

        public async Task<IEnumerable<SpeakerDto>> GetAllPage(int skip, int take)
        {
            var listPage = await _repository.SelectAllPageAsync(skip, take);
            return _mapper.Map<IEnumerable<SpeakerDto>>(listPage);
        }
    }
}

