using Microsoft.EntityFrameworkCore;

namespace Contacts.App.Database;

public sealed class AppDbContext : DbContext
{

    public DbSet<Contact> Contacts { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Contact>().HasData(
            new Contact { Id = 1, Name = "Alice", Email = "alice@example.com", PhoneNumber = "+33612345678" },
            new Contact { Id = 2, Name = "Bob", Email = "bob@example.com", PhoneNumber = "+33687654321" }
        );
    }
}

public sealed class Contact
{
    public int Id { get; set; } // Primary key
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}