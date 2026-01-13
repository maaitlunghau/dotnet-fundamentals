using Microsoft.EntityFrameworkCore;

namespace _08_unit_of_work_practice.Models;

public class DataContext : DbContext
{
    // constructor
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Oreders { get; set; }
}
