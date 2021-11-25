using System;
namespace Api.Api.Controllers
{
    [Router("api/v1/[controller]")]
    [ApiController]
    public class LotsController : ControllerBase
    {
        private ILotService _service;
        private readOnly IMapper _mapper;
        public LotsController(IlotService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{idEvent}")]
        public async Task<ActionResult> GetAllByIdEvent([FromRoute] Guid idEvent)
        {
            try
            {
                return Ok(await _service.(idEvent));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        //  [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EventCreateDto events)
        {
            try
            {
                var result = await _service.Post(events);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetEventWithId", new { id = result.Id })), result);
                }

                return BadRequest("Não foram encontrado valores");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //   [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] EventUpdateDto events)
        {
            try
            {
                var result = await _service.Put(events);
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
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var result = await _service.Get(id);
                if (result == null)
                {
                    return NotFound($"Deleção não obteve êxito com Id: {id}");
                }
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
