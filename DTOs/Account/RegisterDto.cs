using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AvtoElon.API.Demo.DTOs.Account
{
    public class RegisterDto
    {
        [Required]
        [ProtectedPersonalData]
        public string Username { get; set; } = string.Empty;
        [Required]
        [ProtectedPersonalData]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [ProtectedPersonalData]
        public string Password { get; set; } = string.Empty;
    }
}
