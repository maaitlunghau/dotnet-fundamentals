using Microsoft.EntityFrameworkCore;

namespace WebApplication1;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(c => c.Customer)
            .HasForeignKey(c => c.CusId);
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
}
