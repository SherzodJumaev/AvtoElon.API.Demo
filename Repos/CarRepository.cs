using AvtoElon.API.Demo.Data;
using AvtoElon.API.Demo.DTOs.CarDtos;
using AvtoElon.API.Demo.Helpers;
using AvtoElon.API.Demo.Interfaces;
using AvtoElon.API.Demo.Mappers.CarMaps;
using AvtoElon.API.Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace AvtoElon.API.Demo.Repos
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly IFileUploadService _fileUploadService;
        public CarRepository(ApplicationDBContext context, IWebHostEnvironment environment, IFileUploadService fileUploadService)
        {
            _context = context;
            _environment = environment;
            _fileUploadService = fileUploadService;
        }

        public async Task<Car> CreateAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            var lastCarId = car.Id;

            foreach (var item in car.CarPictures)
            {
                if (item.FileName == null || item.FileName.Length == 0)
                    return null;

                await _fileUploadService.UploadFile(item, lastCarId);
            }

            return car;
        }

        public async Task<IEnumerable<Car>> GetAllAsync(QueryObject query)
        {
            var cars = _context.Cars.Include(p => p.CarPicturesList).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                cars = cars.Where(c => c.Name.Contains(query.Name));
            }

            if (query.Category == Category.EhtiyotQismlar)
            {
                cars = cars.Where(c => c.Category == query.Category);
            }
            else if (query.Category == Category.YengilAvtomobillar)
            {
                cars = cars.Where(c => c.Category == query.Category);
            }
            else if (query.Category == Category.Xizmatlar)
            {
                cars = cars.Where(c => c.Category == query.Category);
            }
            else
            {
                cars = cars;
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    cars = query.isDescending ? cars.OrderByDescending(c => c.Name) : cars.OrderBy(c => c.Name);
                }
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    cars = query.isDescending ? cars.OrderByDescending(c => c.Price) : cars.OrderBy(c => c.Price);
                }
            }

            int skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await cars.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Car> GetAsync(int id)
        {
            var car = await _context.Cars.Include(x => x.CarPicturesList).FirstOrDefaultAsync(i => i.Id == id);

            if (car == null)
            {
                return null;
            }

            return car;
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var foundCar = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);

            if (foundCar == null)
            {
                return false;
            }

            _context.Cars.Remove(foundCar);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Car> UpdateAsync(int id, Car car)
        {
            var foundCar = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);

            if (foundCar == null)
            {
                return null;
            }

            foundCar.Category = car.Category;
            foundCar.Currency = car.Currency;
            foundCar.Location = car.Location;
            foundCar.Name = car.Name;
            foundCar.ContactPhone = car.ContactPhone;
            //foundCar.CarPicturesList = car.CarPicturesList;
            foundCar.CreatedAt = car.CreatedAt;
            foundCar.Price = car.Price;
            foundCar.Description = car.Description;

            await _context.SaveChangesAsync();

            return foundCar;
        }
    }
}
