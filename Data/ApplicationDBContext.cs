using AvtoElon.API.Demo.DTOs.CarDtos;
using AvtoElon.API.Demo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AvtoElon.API.Demo.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarPictureDto> CarPictureDtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Car>().HasData(
            //    new Car { Id = 1, Name = "Gentra", Color = "Black", Year = 2020, CarBody = "New", City = "Tashkent", Mileage = 40m, Transmission = "smth", Definition = "smth" },
            //    new Car { Id = 2, Name = "Damas", Color = "White", Year = 2022, CarBody = "New", City = "Jizzakh", Mileage = 39m, Transmission = "smth", Definition = "smth" },
            //    new Car { Id = 3, Name = "Nexia 1.6", Color = "Blue-white", Year = 2019, CarBody = "New", City = "Kashkadarya", Mileage = 45m, Transmission = "smth", Definition = "smth" }
            //);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "1f4f9b8e-3e1a-4b77-9bb8-5fcb3f97e2aa",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2a4f9b8e-3e1a-4b77-9bb8-5fcb3f97e2bb",
                    Name = "User",
                    NormalizedName = "USER"
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
