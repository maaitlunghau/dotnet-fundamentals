using Microsoft.EntityFrameworkCore;

namespace _11_dto_automapper_authentication.Models;

// DatebaseFirst: cũng cần DataContext thôi
// nếu dùng ModelFirst -> tự sinh ra DataContext luôn

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Account> Accounts { get; set; }
}
