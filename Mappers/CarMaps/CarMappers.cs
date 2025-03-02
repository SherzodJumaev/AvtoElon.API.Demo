using AvtoElon.API.Demo.DTOs;
using AvtoElon.API.Demo.Models;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace AvtoElon.API.Demo.Mappers.CarMaps
{
    public static class CarMappers
    {
        public static Car FromCreateCarDtoToCar(this CreateCarDto carDto)
        {
            return new Car
            {
                CarBody = carDto.CarBody,
                City = carDto.City,
                Definition = carDto.Definition,
                Color = carDto.Color,
                Mileage = carDto.Mileage,
                Name = carDto.Name,
                Year = carDto.Year,
                Transmission = carDto.Transmission
            };
        }

        public static CreateCarDto FromCarToCarDto(this Car carModel)
        {
            return new CreateCarDto
            {
                CarBody = carModel.CarBody,
                City = carModel.City,
                Definition = carModel.Definition,
                Color = carModel.Color,
                Mileage = carModel.Mileage,
                Name = carModel.Name,
                Year = carModel.Year,
                Transmission = carModel.Transmission
            };
        }

        public static Car FromUpdateCarDtoToCar(this UpdateCarDto carDto)
        {
            return new Car
            {
                CarBody = carDto.CarBody,
                City = carDto.City,
                Definition = carDto.Definition,
                Color = carDto.Color,
                Mileage = carDto.Mileage,
                Name = carDto.Name,
                Year = carDto.Year,
                Transmission = carDto.Transmission
            };
        }

        public static CarDto FromCarToCarDtoWithId(this Car car)
        {
            return new CarDto
            {
                Id = car.Id,
                CarBody = car.CarBody,
                City = car.City,
                Definition = car.Definition,
                Color = car.Color,
                Mileage = car.Mileage,
                Name = car.Name,
                Year = car.Year,
                Transmission = car.Transmission
            };
        }
    }
}
