namespace Contacts.App.Database;

public class DatabaseConfiguration
{
    public static void SeedDatabase(AppDbContext context)
    {
        // Create DB if it doesn't exist
        if (context.Database.EnsureCreated())
        {
            context.Contacts.AddRange(
                new Contact
                {
                    Name = "Alice Johnson", Email = "alice@example.com", PhoneNumber = "+33612345678"
                },
                new Contact
                {
                    Name = "Bob Smith", Email = "bob@example.com", PhoneNumber = "+33687654321"
                }, new Contact()
            );

            context.SaveChanges();
            Console.WriteLine("Database seeded.");
        }
    }
}