using System;
using Api.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Api.Application.Services
{
    public class UploadService : IUpLoadService
    {

        public async Task<string> SaveImage(IFormFile imageFile)
        {
            //generate a randon name
            string imageName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(imageFile.FileName)}";

            var imagePath = Path.Combine(@"resources/images", imageName);

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return imageName;
        }

        public async Task<string> SaveFile(IFormFile allFile)
        {
            //generate a randon name
            string fileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(allFile.FileName)}";

            var filePath = Path.Combine(@"resources/files", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await allFile.CopyToAsync(fileStream);
            }

            return fileName;

        }

        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(@"resources/images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }

        public void DeleteFile(string fileName)
        {
            var filePath = Path.Combine(@"resources/files", fileName);
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
        }
    }

}

