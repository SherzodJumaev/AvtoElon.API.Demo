using AvtoElon.API.Demo.Data;
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

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            var cars = await _context.Cars.ToListAsync();

            return cars;
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
