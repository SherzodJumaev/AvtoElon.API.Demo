using AvtoElon.API.Demo.Data;
using AvtoElon.API.Demo.Helpers;
using AvtoElon.API.Demo.Interfaces;
using AvtoElon.API.Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace AvtoElon.API.Demo.Repos
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDBContext _context;
        public CarRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Car> CreateAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<IEnumerable<Car>> GetAllAsync(QueryObject query)
        {
            var cars = _context.Cars.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                cars = cars.Where(c => c.Name.Contains(query.Name));
            }

            if (!string.IsNullOrWhiteSpace(query.City))
            {
                cars = cars.Where(c => c.City.Contains(query.City));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    cars = query.isDescending ? cars.OrderByDescending(c => c.Name) : cars.OrderBy(c => c.Name);
                }
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    cars = query.isDescending ? cars.OrderByDescending(c => c.Price) : cars.OrderBy(c => c.Price);
                }
            }

            int skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await cars.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Car?> GetAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);

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

        public async Task<Car?> UpdateAsync(int id, Car car)
        {
            var foundCar = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);

            if (foundCar == null)
            {
                return null;
            }

            foundCar.CarBody = car.CarBody;
            foundCar.City = car.City;
            foundCar.Mileage = car.Mileage;
            foundCar.Year = car.Year;
            foundCar.Color = car.Color;
            foundCar.Definition = car.Definition;
            foundCar.Transmission = car.Transmission;
            foundCar.Name = car.Name;

            await _context.SaveChangesAsync();

            return foundCar;
        }
    }
}
