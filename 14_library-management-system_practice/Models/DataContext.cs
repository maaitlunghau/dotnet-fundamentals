using Microsoft.EntityFrameworkCore;

namespace _14_library_management_system_practice.Models;

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
            .HasIndex(u => u.BookId)
            .IsUnique();

        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                Username = "admin",
                Password = "admin123",
                Role = "admin"
            },
            new User
            {
                UserId = 2,
                Username = "guest1",
                Password = "guest123",
                Role = "guest"
            },
            new User
            {
                UserId = 3,
                Username = "guest2",
                Password = "guest123",
                Role = "guest"
            }
        );

        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                BookId = 1001,
                Title = "Clean Code",
                Author = "Robert C. Martin",
                ISBN = "9780132350884",
                Availability = "Available"
            },
            new Book
            {
                Id = 2,
                BookId = 1002,
                Title = "Clean Architecture",
                Author = "Robert C. Martin",
                ISBN = "9780134494166",
                Availability = "Available"
            },
            new Book
            {
                Id = 3,
                BookId = 1003,
                Title = "Design Patterns",
                Author = "Erich Gamma",
                ISBN = "9780201633610",
                Availability = "Borrowed"
            },
            new Book
            {
                Id = 4,
                BookId = 1004,
                Title = "Refactoring",
                Author = "Martin Fowler",
                ISBN = "9780201485677",
                Availability = "Available"
            },
            new Book
            {
                Id = 5,
                BookId = 1005,
                Title = "The Pragmatic Programmer",
                Author = "Andrew Hunt",
                ISBN = "9780201616224",
                Availability = "Borrowed"
            },
            new Book
            {
                Id = 6,
                BookId = 1006,
                Title = "You Don't Know JS",
                Author = "Kyle Simpson",
                ISBN = "9781491904244",
                Availability = "Available"
            },
            new Book
            {
                Id = 7,
                BookId = 1007,
                Title = "Introduction to Algorithms",
                Author = "Thomas H. Cormen",
                ISBN = "9780262033848",
                Availability = "Available"
            },
            new Book
            {
                Id = 8,
                BookId = 1008,
                Title = "ASP.NET Core MVC",
                Author = "Adam Freeman",
                ISBN = "9781484254394",
                Availability = "Borrowed"
            }
        );
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
}
