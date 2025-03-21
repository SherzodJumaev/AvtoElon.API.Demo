using AvtoElon.API.Demo.Models;

namespace AvtoElon.API.Demo.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
