using Microsoft.EntityFrameworkCore;

namespace _04_entity_relationships.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // relationship
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(p => p.Product)
            .HasForeignKey(p => p.CateId)
            .OnDelete(DeleteBehavior.Restrict);

        // Restrict: không được phép xoá Product khi có liên kết Category
        // Cascade: xoá Category -> xoá luôn Product
        // SetNull: được phép xoá Product, CateId = null
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}
