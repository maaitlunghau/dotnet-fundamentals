using Microsoft.EntityFrameworkCore;

namespace _04_file;

// nhắc lại kiến thức:
//      DataContext kế thừa từ DbContext (cung cấp bởi EF Core)
//      là cầu nối giữa EF Core với Database
//
// Giúp:
//     - Quản lý kết nối tới Database
//     - Tháo tác các Object (Models) với database
//     - nếu kco nó: EF Core ko biết làm sao để thao tác với database

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    // constructor
    public DbSet<Product> Products { get; set; }
}
