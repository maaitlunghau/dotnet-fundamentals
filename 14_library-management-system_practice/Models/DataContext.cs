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
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
}
