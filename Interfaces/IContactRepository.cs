using AvtoElon.API.Demo.Models;

namespace AvtoElon.API.Demo.Interfaces
{
    public interface IContactRepository
    {
        Task<Contact> CreateMessage(Contact contact, CancellationToken cancellationToken = default);
    }
}
