using System;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Api.Pagination;
using Api.Application.Dtos.Event;
using Api.Application.Interfaces;
using Api.Domain.Pagination;
using Microsoft.AspNetCore.Authorization;

namespace Api.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private IEventService _service;
        private IWebHostEnvironment _hostEnvironment;
        private readonly IMapper _mapper;
        public EventsController(IEventService service, IWebHostEnvironment hostEnvironment, IMapper mapper)
        {
            _service = service;
            _hostEnvironment = hostEnvironment;
            _mapper = mapper;
        }


        [HttpGet("complete/{id}")]
        public async Task<ActionResult> GetAllComplete(Guid id)
        {
            try
            {
                return Ok(await _service.GetByIdCompletInformation(id));
            }
            catch (Exception e)
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
                var result = await _service.GetEventById(id);
                if (result == null)
                {
                    return NotFound($"Deleção não obteve êxito com Id: {id}");
                }

                if (await _service.Delete(id))
                {
                    DeleteImage(result.EventImage);
                    return Ok(await _service.Delete(id));
                }
                else {
                     throw new Exception($"Erro ao deletar evento {result.Theme}");
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }

         [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAllByTerm([FromQuery] PageParams pageParams)
        {
            try
            {
                var result = await _service.GetAllByTerm(pageParams);
                if (result == null) return NoContent();
                Response.AddPagination(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPage);

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetEventWithId")]
        public async Task<ActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                var result = await _service.GetEventById(id);
                if (result == null)
                {
                    return NotFound($"Pesquisa não obteve êxito com Id: {id}");
                }
                return Ok(await _service.GetEventById(id));

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


        //////////////////////  Updaload de imagem
        [HttpPost("updalod-image/{eventId}")]
        public async Task<ActionResult> UploadImage(Guid eventId)
        {
    
            try
            {
                var eventResult = await _service.GetEventById(eventId);
                if (eventResult is null) return NoContent();

                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    DeleteImage(eventResult.EventImage);
                    eventResult.EventImage = await SaveImage(file);
                }
                var resultMap = _mapper.Map<EventUpdateDto>(eventResult);
                var eventReturn = await _service.Put(resultMap);

                return Ok(eventReturn);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Erro ao salvar imagem", ex.Message);
            }
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile) //Save image on folder Resourses
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');

            imageName = $"{imageName}{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(imageFile.FileName)}";

            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @"resources/images", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return imageName;
        }

        [NonAction]  //delete the image from folder Resourses
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @"resources/images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}

