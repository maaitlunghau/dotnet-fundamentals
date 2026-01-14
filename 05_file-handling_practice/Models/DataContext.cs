using Microsoft.EntityFrameworkCore;
namespace _05_file_handling_practice.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
}
