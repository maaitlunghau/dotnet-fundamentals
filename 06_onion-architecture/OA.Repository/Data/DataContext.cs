using Microsoft.EntityFrameworkCore;
using OA.Domain.Model;

namespace OA.Repository.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }
    public DbSet<Employee> Employees { get; set; }
}
