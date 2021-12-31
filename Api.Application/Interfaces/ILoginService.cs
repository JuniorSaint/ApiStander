using System.Threading.Tasks;
using Api.Application.Dtos.Login;

namespace Api.Application.Interfaces
{
    public interface ILoginService
    {
        Task<object> FindByLoginAsync(LoginDto user);
    }
}
