using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Api.Application.Interfaces
{
    public interface IUpLoadService
    {
        Task<string> SaveImage(IFormFile imageFile);
        Task<string> SaveFile(IFormFile allFile);
        void DeleteImage(string imageName);
        void DeleteFile(string fileName);
    }
}

