using System;
using Api.Application.Dtos.Login;
using Api.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Api.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDto loginDto, [FromServices] ILoginService service)
        {

            if (loginDto == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await service.FindByLoginAsync(loginDto);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

