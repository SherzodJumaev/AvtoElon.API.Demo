using AvtoElon.API.Demo.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvtoElon.API.Demo.DTOs.CarDtos
{
    public class CarDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public Category Category { get; set; }
        public Location Location { get; set; }
        public string ContactName { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public List<string> CarPicturesNames { get; set; }
    }
}
