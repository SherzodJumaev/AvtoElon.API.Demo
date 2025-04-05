using AvtoElon.API.Demo.Data;
using AvtoElon.API.Demo.DTOs.CarDtos;
using AvtoElon.API.Demo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AvtoElon.API.Demo.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly ApplicationDBContext _context;
        public FileUploadService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<string> UploadFile(IFormFile file, int carId)
        {
            List<string> validExtentions = new List<string>
            {
                ".jpg", ".png", ".jfif", ".gif"
            };

            string extention = Path.GetExtension(file.FileName);
            if (!validExtentions.Contains(extention))
            {
                return $"Extention is not valid ({string.Join(',', validExtentions)})";
            }

            long size = file.Length;
            if (size > (5 * 1024 * 1024))
            {
                return "Maximum size can be 5MB";
            }

            string fileName = Guid.NewGuid().ToString() + extention;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Images");

            using FileStream stream = new FileStream(path + "/" + fileName, FileMode.Create);
            file.CopyTo(stream);

            var carPictureDto = new CarPictureDto
            {
                ImageName = fileName,
                ImagePath = path,
                CarId = carId,
            };

            _context.CarPictureDtos.Add(carPictureDto);
            await _context.SaveChangesAsync();

            return fileName;
        }
    }
}
