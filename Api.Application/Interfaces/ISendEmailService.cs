using Api.Application.Dtos.Email;

namespace Api.Application.Interfaces
{
    public interface ISendEmailSerivce
    {
        Task SendMail(SendEmailDto sendEmail);
    }
}
