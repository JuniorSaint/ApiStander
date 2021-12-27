using System;
using Api.Application.Dtos.ListSocialMedia;
using Api.Application.Interfaces;
using Api.Domain.Interfaces;
using AutoMapper;

namespace Api.Application.Services
{
    public class ListSocialMediaService : IListSocialMediaService
    {
        private IListSocialMediaRepository _repository;
        private readonly IMapper _mapper;

        public ListSocialMediaService(IListSocialMediaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ListSocialMediaDto>> GetListSocialMedias()
        {
            try
            {
                var entity = await _repository.GetAllListSocialMedia();
                return _mapper.Map<IEnumerable<ListSocialMediaDto>> ( entity );
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter lista de rede social", ex);
            }
        }
    }
}

