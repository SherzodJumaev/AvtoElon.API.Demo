using AvtoElon.API.Demo.Models;

namespace AvtoElon.API.Demo.Interfaces
{
    public interface IPortfolioRepository
    {
        Task<IEnumerable<Car>> GetPortfolioAsync(AppUser appUser, CancellationToken cancellationToken = default);
        Task<Car> UpdatePortfolioAsync(AppUser appUser, int id, Car car, CancellationToken cancellationToken = default);
        Task<bool> DeletePortfolioAsync(AppUser appUser, int id, CancellationToken cancellationToken = default);
    }
}
