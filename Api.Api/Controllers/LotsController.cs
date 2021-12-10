using System;
using System.Net;
using System.Threading.Tasks;
using Api.Application.Dtos.Event;
using Api.Application.Dtos.Lot;
using Api.Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LotsController : ControllerBase
    {
        private ILotService _service;
        private readonly IMapper _mapper;
        public LotsController(ILotService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{idEvent}")]
        public async Task<ActionResult> GetAllByIdEvent([FromRoute] Guid idEvent)
        {
            try
            {
                return Ok(await _service.GetLotsByEventAsync(idEvent));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //   [Authorize("Bearer")]
        [HttpPut("{idEvent}")]
        public async Task<ActionResult> Put([FromBody] IEnumerable<LotUpdateDto> lots,[FromRoute] Guid idEvent)
        {
            try
            {
                var result = await _service.SaveLotsAsync(lots, idEvent);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Dados não foram atualizados");
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //   [Authorize("Bearer")]
        [HttpDelete("{idEvent}/{idLot}")]
        public async Task<ActionResult> Delete([FromRoute] Guid idLot,[FromRoute] Guid idEvent)
        {
            try
            {
                var result = await _service.GetLotByIdAsync(idLot, idEvent);
                if (result == null)
                {
                    return NotFound($"Deleção não obteve êxito com Id: {idLot}");
                }
                return Ok(await _service.DeleteAsync(idLot));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
