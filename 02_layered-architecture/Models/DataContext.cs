using _02_layered_architecture.Models;
using Microsoft.EntityFrameworkCore;

namespace _02_layered_architecture;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }
    public DbSet<Product> Products { get; set; }
}
