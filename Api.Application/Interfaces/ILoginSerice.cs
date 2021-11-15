using System.Threading.Tasks;
using Api.Application.Dtos.Login;

namespace Api.Applications.Interfaces
{
    public interface ILoginService
    {
        Task<object> FindByLoginAsync(LoginDto user);
    }
}
