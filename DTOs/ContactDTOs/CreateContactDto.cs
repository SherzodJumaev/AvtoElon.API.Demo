using System.ComponentModel.DataAnnotations;

namespace AvtoElon.API.Demo.DTOs.ContactDTOs
{
    public class CreateContactDto
    {
        [Required]
        [MaxLength(30)]
        public string Fullname { get; set; }

        [Required]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string Theme { get; set; }

        [Required]
        [MaxLength(250)]
        public string Message { get; set; }
    }
}
