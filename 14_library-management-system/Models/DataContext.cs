using Microsoft.EntityFrameworkCore;

namespace _14_library_management_system.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<Book>()
            .HasIndex(b => b.ISBN)
            .IsUnique();

        modelBuilder.Entity<Book>()
            .HasData(
                new Book
                {
                    Id = 1,
                    Title = "The Great Gatsby",
                    Author = "F. Scott",
                    ISBN = "1234567890123",
                    Availability = "Available"
                },
                new Book
                {
                    Id = 2,
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    ISBN = "2345678901234",
                    Availability = "Borrowed"
                },
                new Book
                {
                    Id = 3,
                    Title = "1984",
                    Author = "George Orwell",
                    ISBN = "3456789012345",
                    Availability = "Available"
                }
            );
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
}
