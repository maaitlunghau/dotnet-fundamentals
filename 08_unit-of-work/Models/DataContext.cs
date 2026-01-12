using Microsoft.EntityFrameworkCore;

namespace _08_unit_of_work.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
}
