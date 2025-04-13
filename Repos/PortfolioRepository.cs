using AvtoElon.API.Demo.Data;
using AvtoElon.API.Demo.Interfaces;
using AvtoElon.API.Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace AvtoElon.API.Demo.Repos
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDBContext _context;

        public PortfolioRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetPortfolioAsync(AppUser appUser, CancellationToken cancellationToken = default)
        {
            return await _context.Cars.Where(u => u.ContactName == appUser.UserName)
                .Select(car => new Car
                {
                    Id = car.Id,
                    Name = car.Name,
                    Price = car.Price,
                    CreatedAt = car.CreatedAt,
                    CarPictures = car.CarPictures,
                    CarPicturesList = car.CarPicturesList,
                    Category = car.Category,
                    ContactName = car.ContactName,
                    ContactPhone = car.ContactPhone,
                    Currency = car.Currency,
                    Description = car.Description,
                    Location = car.Location,
                }).ToListAsync(cancellationToken);
        }

        public async Task<Car> UpdatePortfolioAsync(AppUser appUser, int id, Car car, CancellationToken cancellationToken = default)
        {
            var userPortfolio = await _context.Cars.Where(u => u.ContactName == appUser.UserName).Select(c => c).ToListAsync();
            var foundCar = userPortfolio.FirstOrDefault(c => c.Id == id);

            if (userPortfolio == null || foundCar == null)
                return null;

            foundCar.Category = car.Category;
            foundCar.Currency = car.Currency;
            foundCar.Location = car.Location;
            foundCar.Name = car.Name;
            foundCar.ContactPhone = car.ContactPhone;
            foundCar.CreatedAt = car.CreatedAt;
            foundCar.Price = car.Price;
            foundCar.Description = car.Description;

            await _context.SaveChangesAsync();

            return foundCar;
        }
        public async Task<bool> DeletePortfolioAsync(AppUser appUser, int id, CancellationToken cancellationToken = default)
        {
            var userPortfolio = await _context.Cars.Where(u => u.ContactName == appUser.UserName).Select(c => c).ToListAsync();
            var foundCar = userPortfolio.FirstOrDefault(c => c.Id == id);

            if (userPortfolio == null || foundCar == null)
                return false;

            _context.Cars.Remove(foundCar);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
