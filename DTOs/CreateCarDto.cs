using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AvtoElon.API.Demo.DTOs
{
    public class CreateCarDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Color { get; set; } = string.Empty;
        [Required]
        public string CarBody { get; set; } = string.Empty;
        [Required]
        public string Transmission { get; set; } = string.Empty;
        [Required]
        public int Year { get; set; }
        [Required]
        public long Price { get; set; }
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string? Definition { get; set; }
        [Required]
        public decimal Mileage { get; set; }
    }
}
