using Api.Application.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Api.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ListSocialMediasController : ControllerBase
    {
        private IListSocialMediaService _service;
        private readonly IMapper _mapper;
        public ListSocialMediasController(IListSocialMediaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetListSocialMedia()
        {
            try
            {
                return Ok(await _service.GetListSocialMedias());
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("erro ao obter lista de redes sociais", e.Message);
            }
        }
    }
}

