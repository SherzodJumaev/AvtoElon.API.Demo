using AvtoElon.API.Demo.DTOs.ContactDTOs;
using AvtoElon.API.Demo.Models;

namespace AvtoElon.API.Demo.Mappers.ContactMaps
{
    public static class ContactMappers
    {
        public static Contact ToContactFromCreate(this CreateContactDto createContactDto)
        {
            return new Contact
            {
                Fullname = createContactDto.Fullname,
                Email = createContactDto.Email,
                Theme = createContactDto.Theme,
                Message = createContactDto.Message
            };
        }
    }
}
