using AvtoElon.API.Demo.Data;

namespace AvtoElon.API.Demo.Helpers
{
    public class CheckCar
    {
        private readonly ApplicationDBContext _context;
        public CheckCar(ApplicationDBContext context)
        {
            _context = context;
        }
    }
}
