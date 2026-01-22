using Microsoft.EntityFrameworkCore;

namespace _15_product_management_system.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
}
