using AvtoElon.API.Demo.Data;
using AvtoElon.API.Demo.DTOs.CarDtos;
using AvtoElon.API.Demo.Interfaces;

namespace AvtoElon.API.Demo.Services
{
    public class DeleteCarPictures : IDeleteCarPictures
    {
        private readonly ApplicationDBContext _context;
        public DeleteCarPictures(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CarPictureDto>> DeleteCarPicturesAsync(int id)
        {
            var pictures = _context.CarPictureDtos.Select(p => p).Where(p => p.CarId == id);

            if (pictures is null)
                return null;

            foreach (var item in pictures)
            {
                _context.CarPictureDtos.Remove(item);
            }

            await _context.SaveChangesAsync();

            return pictures;
        }
    }
}
