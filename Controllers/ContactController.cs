using AvtoElon.API.Demo.DTOs.ContactDTOs;
using AvtoElon.API.Demo.Interfaces;
using AvtoElon.API.Demo.Mappers.ContactMaps;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AvtoElon.API.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // POST api/<ContactController>
        [HttpPost("create-message")]
        public async Task<IActionResult> CreateMessage([FromBody] CreateContactDto createContactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var messageModel = createContactDto.ToContactFromCreate();

            var createdMessage = await _contactRepository.CreateMessage(messageModel);

            return Created();
        }
    }
}
