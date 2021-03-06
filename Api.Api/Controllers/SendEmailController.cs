using Microsoft.AspNetCore.Mvc;
using Api.Application.Dtos.Email;
using Api.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Event.Api.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private ISendEmailSerivce _service;
        public SendEmailController(ISendEmailSerivce service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task EnviaEmail([FromBody] SendEmailDto email)
        {
            try
            {
                await _service.SendMail(email);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
