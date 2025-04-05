using AvtoElon.API.Demo.Models;
using System.ComponentModel.DataAnnotations;

namespace AvtoElon.API.Demo.DTOs.CarDtos
{
    public class CarPictureDto
    {
        [Key]
        public int CarPictureId { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
