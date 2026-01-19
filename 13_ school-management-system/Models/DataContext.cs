using Microsoft.EntityFrameworkCore;

namespace _13__school_management_system.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }

}
