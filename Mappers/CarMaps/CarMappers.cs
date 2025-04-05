using AvtoElon.API.Demo.DTOs.CarDtos;
using AvtoElon.API.Demo.Helpers;
using AvtoElon.API.Demo.Models;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace AvtoElon.API.Demo.Mappers.CarMaps
{
    public static class CarMappers
    {
        public static Car FromCreateCarDtoToCar(this CreateCarDto carDto, EnumQueryObject queryObject, AppUser appUser)
        {
            return new Car
            {
                Name = carDto.CarName,
                Description = carDto.Description,
                Price = carDto.CarPrice,
                Currency = queryObject.Currency,
                Category = queryObject.Category,
                Location = queryObject.Location,
                ContactName = appUser.UserName,
                ContactPhone = carDto.ContactPhone,
                CarPictures = carDto.CarPictures
            };
        }

        public static CarDto FromCarToCarDto(this Car carModel)
        {
            return new CarDto
            {
                Name = carModel.Name,
                Price = carModel.Price,
                CreatedAt = carModel.CreatedAt,
                Category = carModel.Category,
                ContactName = carModel.ContactName,
                ContactPhone = carModel.ContactPhone,
                Currency = carModel.Currency,
                Description = carModel.Description,
                Location = carModel.Location,
                CarPicturesNames = carModel.CarPicturesList.Select(p => p.ImageName).ToList()
            };
        }

        public static Car FromUpdateCarDtoToCar(this UpdateCarDto carDto, EnumQueryObject queryObject)
        {
            return new Car
            {
                Price = carDto.CarPrice,
                CreatedAt = DateTime.Now,
                Category = queryObject.Category,
                Currency = queryObject.Currency,
                Location = queryObject.Location,
                ContactPhone = carDto.ContactPhone,
                Description = carDto.Description,
                Name = carDto.CarName,
                CarPicturesList = carDto.CarPictures.Select(cp => new CarPictureDto { ImageName = cp.FileName }).ToList()
            };
        }

        public static Car FromUpdateCarDtoToCarWithoutImage(this UpdateCarDto carDto, EnumQueryObject queryObject)
        {
            return new Car
            {
                Price = carDto.CarPrice,
                CreatedAt = DateTime.Now,
                Category = queryObject.Category,
                Currency = queryObject.Currency,
                Location = queryObject.Location,
                ContactPhone = carDto.ContactPhone,
                Description = carDto.Description,
                Name = carDto.CarName,
            };
        }
    }
}
