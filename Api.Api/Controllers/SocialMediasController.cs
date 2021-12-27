using System;
using System.Net;
using Api.Application.Dtos.SocialMedia;
using Api.Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Api.Controllers
{
	[Route("api/v1/[controller]")]
    [ApiController]
	public class SocialMediasController : ControllerBase
	{
		private ISocialMediaService _service;
		private readonly IMapper _mapper;

		public SocialMediasController(ISocialMediaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{idSpeaker}")]
        public async Task<ActionResult> GetAllByIdSpeaker([FromRoute] Guid idSpeaker)
        {
            try
            {
                return Ok(await _service.GetSocialMediasBySpeaker(idSpeaker));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        //   [Authorize("Bearer")]
        [HttpPut("{idSpeaker}")]
        public async Task<ActionResult> Put([FromBody] IEnumerable<SocialMediaDto> socialMedias, [FromRoute] Guid idSpeaker)
        {
            try
            {
                var result = await _service.SaveLotsAsync(socialMedias, idSpeaker);
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
        [HttpDelete("{idSpeaker}/{idSocialMedia}")]
        public async Task<ActionResult> Delete([FromRoute] Guid idSpeaker, [FromRoute] Guid idSocialMedia)
        {
            try
            {
                var result = await _service.GetSocialMediasBySpeakerBySocial(idSpeaker, idSocialMedia);
                if (result == null)
                {
                    return NotFound($"Deleção não obteve êxito com Id: {idSocialMedia}");
                }
                return Ok(await _service.Delete(idSocialMedia));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}

