using Api.Application.Dtos;
using Api.Application.Dtos.Event;
using Api.Application.Interfaces;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Pagination;
using AutoMapper;

namespace Api.Application.Services
{
    public class EventService : IEventService
    {
        private IEventRepository _repository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EventDto> GetEventById(Guid id)
        {
            var entity = await _repository.SelectByIdAsync(id);
            return _mapper.Map<EventDto>(entity);
        }

        public async Task<IEnumerable<EventDto>> GetAll()
        {
            var listEntity = await _repository.SelectAllAsync();
            return _mapper.Map<IEnumerable<EventDto>>(listEntity);
        }

        public async Task<EventDto> Post(EventCreateDto evento)
        {
            var entity = _mapper.Map<EventEntity>(evento);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<EventDto>(result);
        }

        public async Task<EventDto> Put(EventUpdateDto evento)
        {
            var entity = _mapper.Map<EventEntity>(evento);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<EventDto>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<PageList<EventDto>> GetAllByTerm(PageParams pageParams)
        {
            var entity = await _repository.GetEventByTermAsync(pageParams);
            var result =  _mapper.Map<PageList<EventDto>>(entity);

            // mapped and fix the problem whit automapper with params
            result.CurrentPage = entity.CurrentPage;
            result.TotalPage = entity.TotalPage;
            result.PageSize = entity.PageSize;
            result.TotalCount = entity.TotalCount;

            return result;
        }

        public async Task<EventDto> GetByIdCompletInformation(Guid id)
        {
            var listEntity = await _repository.GetAllCompleteAsync(id);
            return _mapper.Map<EventDto>(listEntity);
        }

        public async Task<EventDto> PostUpload(EventUpdateDto evento, Guid id)
        {
            var entity = _mapper.Map<EventEntity>(evento);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<EventDto>(result);
        }
    }
}

