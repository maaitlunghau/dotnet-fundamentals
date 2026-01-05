using Microsoft.EntityFrameworkCore;

namespace _03_;

// DataContext: trái time của Entity Framework (EF Core)
//              cầu nối giữa C# <---> Database (SQL Server)
// 
// Giúp: 
//     1. Query DB
//     2. Save data to DB
//     3. Mapping Models <--> Tables
//     4. Config relationship giữa các Models
//     5. Migrations: tạo/sửa bảng trong DB từ Models

public class DataContext : DbContext
{
    // constructor
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // nơi cấu hình cho các Models:
        // -- validate
        // -- relationship
        // -- indexes
        // -- default values
        // -- constraints        

        base.OnModelCreating(modelBuilder);

        // validate (but recommended validate in Model than at here)
        // validate ở Model tốt hơn, vì:
        // -- dễ đọc
        // -- dễ maintain
        // -- clean code hơn

        // modelBuilder.Entity<Product>()
        //    .Property(p => p.Name)
        //    .IsRequired();

        // relationship
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.CateId)
            .OnDelete(DeleteBehavior.Cascade);

        // Restrict: không được phép xoá khi có ràng buộc
        // Cascade: được phép xoá, xoá Category -> xoá luôn Products liên quan 
        // SetNull: được phép xoá, set CateId = null
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}