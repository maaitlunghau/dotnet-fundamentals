using Microsoft.EntityFrameworkCore;
namespace _05_file_handling_practice.Models;

public class DataContext : DbContext
{
    /// <summary>
/// Initializes a new DataContext configured with the specified EF Core options.
/// </summary>
/// <param name="options">The options used to configure the context, such as provider, connection string, and any EF Core behavior settings.</param>
public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
}