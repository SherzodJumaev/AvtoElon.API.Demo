using AvtoElon.API.Demo.DTOs.CarDtos;

namespace AvtoElon.API.Demo.Interfaces
{
    public interface IDeleteCarPictures
    {
        Task<IEnumerable<CarPictureDto>> DeleteCarPicturesAsync(int id);
    }
}
