using Microsoft.EntityFrameworkCore;

namespace _01_getting_started.Models;

// recall:
// DataContext: cấu nối giữa Database và .NET
// nhờ nó:
//      + thao tác được với Database (thêm, sửa, xoá, ...)
//      + relationship

public class DataContext : DbContext
{
    // constructor (được inject từ Progam.cs)
    public DataContext(DbContextOptions options) : base(options) { }

    // database declaration
    // bước này: mục đích để nói với EF rằng: trong database SẼ CÓ bảng Employees
    public DbSet<Employee> Employees { get; set; }
}
