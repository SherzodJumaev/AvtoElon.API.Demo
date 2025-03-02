using AvtoElon.API.Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace AvtoElon.API.Demo.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Name = "Gentra", Color = "Black", Year = 2020, CarBody = "New", City="Tashkent", Mileage = 40m, Transmission = "smth", Definition = "smth"},
                new Car { Id = 2, Name = "Damas", Color = "White", Year = 2022, CarBody = "New", City="Jizzakh", Mileage = 39m, Transmission = "smth", Definition = "smth"},
                new Car { Id = 3, Name = "Nexia 1.6", Color = "Blue-white", Year = 2019, CarBody = "New", City="Kashkadarya", Mileage = 45m, Transmission = "smth", Definition = "smth"}
            );
        }
    }
}
