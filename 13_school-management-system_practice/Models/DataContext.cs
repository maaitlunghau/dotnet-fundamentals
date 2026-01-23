using Microsoft.EntityFrameworkCore;

namespace _13_school_management_system_practice.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Teacher>()
            .HasIndex(t => t.Email)
            .IsUnique();

        modelBuilder.Entity<Teacher>().HasData(
            new Teacher
            {
                Id = 1,
                TeacherName = "Nguyễn Văn A",
                Department = "Công nghệ thông tin",
                Email = "nguyenvana@school.com"
            },
            new Teacher
            {
                Id = 2,
                TeacherName = "Trần Thị B",
                Department = "Toán học",
                Email = "tranthib@school.com"
            },
            new Teacher
            {
                Id = 3,
                TeacherName = "Lê Văn C",
                Department = "Vật lý",
                Email = "levanc@school.com"
            }
        );

        modelBuilder.Entity<Student>().HasData(
            new Student
            {
                Id = 1,
                StudentName = "Phạm Minh Hoàng",
                DateOfBirth = new DateTime(2002, 5, 10),
                Address = "123 Nguyễn Trãi, Quận 5, TP.HCM",
                TeacherId = 1
            },
            new Student
            {
                Id = 2,
                StudentName = "Nguyễn Thị Lan",
                DateOfBirth = new DateTime(2003, 8, 20),
                Address = "45 Lê Lợi, Quận 1, TP.HCM",
                TeacherId = 1
            },
            new Student
            {
                Id = 3,
                StudentName = "Trần Quốc Khánh",
                DateOfBirth = new DateTime(2001, 12, 15),
                Address = "78 Hai Bà Trưng, Hà Nội",
                TeacherId = 1
            },
            new Student
            {
                Id = 4,
                StudentName = "Lê Thị Hồng",
                DateOfBirth = new DateTime(2002, 3, 25),
                Address = "12 Trường Chinh, Đà Nẵng",
                TeacherId = 2
            },
            new Student
            {
                Id = 5,
                StudentName = "Võ Minh Tuấn",
                DateOfBirth = new DateTime(2003, 7, 5),
                Address = "90 Nguyễn Huệ, Huế",
                TeacherId = 2
            },
            new Student
            {
                Id = 6,
                StudentName = "Phan Thanh Tùng",
                DateOfBirth = new DateTime(2001, 9, 18),
                Address = "66 Lý Thường Kiệt, TP.HCM",
                TeacherId = 2
            },
            new Student
            {
                Id = 7,
                StudentName = "Đặng Ngọc Mai",
                DateOfBirth = new DateTime(2002, 11, 30),
                Address = "34 Pasteur, TP.HCM",
                TeacherId = 3
            },
            new Student
            {
                Id = 8,
                StudentName = "Bùi Quốc Dũng",
                DateOfBirth = new DateTime(2003, 2, 14),
                Address = "101 Cách Mạng Tháng 8, Cần Thơ",
                TeacherId = 3
            }
        );
    }

    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
}