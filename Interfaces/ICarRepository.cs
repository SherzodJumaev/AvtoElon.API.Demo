using AvtoElon.API.Demo.Helpers;
using AvtoElon.API.Demo.Models;

namespace AvtoElon.API.Demo.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllAsync(QueryObject query);
        Task<Car?> GetAsync(int id);
        Task<Car> CreateAsync(Car car);
        Task<Car?> UpdateAsync(int id, Car car);
        Task<bool> SoftDeleteAsync(int id);
    }
}
