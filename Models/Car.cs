using AvtoElon.API.Demo.DTOs.CarDtos;
using AvtoElon.API.Demo.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvtoElon.API.Demo.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public Category Category { get; set; }
        public Location Location { get; set; }
        public string ContactName { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [NotMapped]
        public List<IFormFile> CarPictures { get; set; }
        public List<CarPictureDto> CarPicturesList { get; set; } = [];

        public string UserID { get; set; }
        public AppUser AppUser { get; set; } = null!;
    }
}
