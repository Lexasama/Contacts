using Contacts.App.Database;

namespace Contacts.App.Services;

public interface IContactService
{
    Task<int> CreateAsync(string name, string email, string phoneNumber);
}

public class ContactService : IContactService
{

    private readonly AppDbContext _dbContext;

    public ContactService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> CreateAsync(string name, string email, string phoneNumber)
    {

        var contact = new Contact
        {
            Name = name, Email = email, PhoneNumber = phoneNumber
        };

        _dbContext.Contacts.Add(contact);
        _dbContext.SaveChanges();

        return Task.FromResult(contact.Id);
    }
}