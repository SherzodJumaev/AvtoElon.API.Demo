using Microsoft.AspNetCore.Identity;

namespace AvtoElon.API.Demo.Models
{
    public class AppUser : IdentityUser
    {
        public List<Car> Cars { get; set; } = [];
    }
}
