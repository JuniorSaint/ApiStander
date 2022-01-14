using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Api.Application.Interfaces;
using Api.Application.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Api.Domain.Pagination;
using Api.Api.Pagination;

namespace Api.Api.Controllers
{
    [Route(template: "api/v1/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private IUserService _service { get; set; }
        public UsersController(IUserService service)
        {
            _service = service;
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

        [Authorize]
        [HttpGet]
        [Route("{id}", Name = "GetById")]
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


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserCreateDto user)
        {
            try
            {
                var resultExist = await _service.GetByEmail(user.UserEmail);

                if (resultExist == null)
                {
                    var result = await _service.Post(user);
                    if (result != null)
                    {
                        return Created(new Uri(Url.Link("GetById", new { id = result.Id })), result);
                    }
                }
                else
                {
                    return Conflict("Usuário já cadastrado");
                }

                return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserUpdateDto user)
        {
            try
            {
                var result = await _service.Put(user);
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

        [Authorize]
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
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}