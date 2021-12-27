using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Api.Application.Dtos.Speaker;
using Api.Application.Interfaces;


namespace Api.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SpeakersController : ControllerBase
    {
        private ISpeakerService _service { get; set; }
        private IWebHostEnvironment _hostEnvironment;
        private readonly IMapper _mapper;
        public SpeakersController(ISpeakerService service, IWebHostEnvironment hostEnvironment, IMapper mapper)
        {
            _service = service;
            _hostEnvironment = hostEnvironment;
            _mapper = mapper;
        }

        // [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetSpeakerWithId")]
        public async Task<ActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                var result = await _service.GetById(id);
                if (result == null)
                {
                    return NotFound($"Pesquisa não obteve êxito com Id: {id}");
                }
                return Ok(await _service.GetById(id));

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        //  [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SpeakerCreateDto speaker)
        {
            try
            {
                var result = await _service.Post(speaker);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetSpeakerWithId", new { id = result.Id })), result);
                }

                return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //   [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] SpeakerUpdateDto speaker)
        {
            try
            {
                var result = await _service.Put(speaker);
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
                var result = await _service.GetById(id);
                if (result == null)
                {
                    return NotFound($"Deleção não obteve êxito com Id: {id}");
                }
                if (await _service.Delete(id))
                {
                    DeleteImage(result.SpeakerImage);
                    return Ok(await _service.Delete(id));
                }
                else
                {
                    throw new Exception($"Erro ao deletar evento {result.SpeakerName}");
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        //////////////////////  Updaload de imagem
        [HttpPost("updalod-image/{speakerId}")]
        public async Task<ActionResult> UploadImage(Guid speakerId)
        {

            try
            {
                var result = await _service.GetById(speakerId);
                if (result is null) return NoContent();

                var file = Request.Form.Files[0];
                Console.WriteLine(file);
                if (file.Length > 0)
                {
                    DeleteImage(result.SpeakerImage);
                    result.SpeakerImage = await SaveImage(file);
                }
                var resultMap = _mapper.Map<SpeakerUpdateDto>(result);
                var speakerReturn = await _service.Put(resultMap);

                return Ok(speakerReturn);
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