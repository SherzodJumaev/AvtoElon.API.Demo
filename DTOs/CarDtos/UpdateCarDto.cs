using System.ComponentModel.DataAnnotations;

namespace AvtoElon.API.Demo.DTOs.CarDtos
{
    public class UpdateCarDto
    {
        public string CarName { get; set; }
        public string Description { get; set; }
        public decimal CarPrice { get; set; }
        public string ContactPhone { get; set; }
        public List<IFormFile> CarPictures { get; set; }
    }
}
