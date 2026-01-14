using Microsoft.EntityFrameworkCore;
namespace _10_dto_many_to_many.Models;

public class DataContext : DbContext
{
    /// <summary>
/// Initializes a new instance of <see cref="DataContext"/> with the specified context options.
/// </summary>
/// <param name="options">Options that configure the database context.</param>
public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    /// <summary>
    /// Configures the EF Core model for the context, including the composite primary key and relationships for the StudentCourse join entity.
    /// </summary>
    /// <param name="modelBuilder">The builder used to configure entity types and relationships for the context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentId, sc.CourseId });
        modelBuilder.Entity<StudentCourse>()
            .HasOne(sc => sc.Student)
            .WithMany(s => s.StudentCourses)
            .HasForeignKey(sc => sc.StudentId);
        modelBuilder.Entity<StudentCourse>()
            .HasOne(sc => sc.Course)
            .WithMany(c => c.StudentCourses)
            .HasForeignKey(sc => sc.CourseId);
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }
}