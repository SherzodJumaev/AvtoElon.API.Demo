using AvtoElon.API.Demo.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AvtoElon.API.Demo.DTOs.CarDtos
{
    public class CreateCarDto
    {
        [Required]
        public string CarName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal CarPrice { get; set; }
        [Required]
        public string ContactPhone { get; set; }
        [Required]
        public List<IFormFile> CarPictures { get; set; }
    }
}
