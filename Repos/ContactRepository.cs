using AvtoElon.API.Demo.Data;
using AvtoElon.API.Demo.Interfaces;
using AvtoElon.API.Demo.Models;

namespace AvtoElon.API.Demo.Repos
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDBContext _context;
        public ContactRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Contact> CreateMessage(Contact contact, CancellationToken cancellationToken)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return contact;
        }
    }
}
