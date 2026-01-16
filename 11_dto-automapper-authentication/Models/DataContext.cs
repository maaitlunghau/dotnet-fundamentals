using Microsoft.EntityFrameworkCore;

namespace _11_dto_automapper_authentication.Models;

// nếu kh dùng DataContext thì dùng DatebaseFirst 
// (nhưng nó cũng cần DataContext thôi)
// nếu dùng ModelFirst -> cũng tự sinh ra DataContext luôn

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Account> Accounts { get; set; }
}
