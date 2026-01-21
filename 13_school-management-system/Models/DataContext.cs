using Microsoft.EntityFrameworkCore;

namespace _13_school_management_system.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Teacher>()
            .HasIndex(t => t.Email)
            .IsUnique();

        modelBuilder.Entity<Teacher>()
            .HasData(
                new Teacher
                {
                    TeacherId = 1,
                    TeacherName = "Nguyễn Văn A",
                    Department = "Công nghệ thông tin",
                    Email = "a.nguyen@school.com"
                },
                new Teacher
                {
                    TeacherId = 2,
                    TeacherName = "Trần Thị B",
                    Department = "Khoa học máy tính",
                    Email = "b.tran@school.com"
                },
                new Teacher
                {
                    TeacherId = 3,
                    TeacherName = "Lê Hoàng C",
                    Department = "Hệ thống thông tin",
                    Email = "c.le@school.com"
                },
                new Teacher
                {
                    TeacherId = 4,
                    TeacherName = "Phạm Minh D",
                    Department = "Kỹ thuật phần mềm",
                    Email = "d.pham@school.com"
                }
            );

        modelBuilder.Entity<Student>()
            .HasData(
                new Student
                {
                    StudentId = 1,
                    StudentName = "Lê Văn E",
                    DateOfBirth = new DateTime(2002, 5, 10),
                    Address = "Hà Nội",
                    TeacherId = 1
                },
                new Student
                {
                    StudentId = 2,
                    StudentName = "Phạm Thị F",
                    DateOfBirth = new DateTime(2003, 8, 20),
                    Address = "TP. Hồ Chí Minh",
                    TeacherId = 1
                },
                new Student
                {
                    StudentId = 3,
                    StudentName = "Hoàng Văn G",
                    DateOfBirth = new DateTime(2001, 12, 1),
                    Address = "Đà Nẵng",
                    TeacherId = 2
                },
                new Student
                {
                    StudentId = 4,
                    StudentName = "Nguyễn Thị H",
                    DateOfBirth = new DateTime(2002, 3, 15),
                    Address = "Cần Thơ",
                    TeacherId = 2
                },
                new Student
                {
                    StudentId = 5,
                    StudentName = "Trần Văn I",
                    DateOfBirth = new DateTime(2003, 7, 5),
                    Address = "Hải Phòng",
                    TeacherId = 3
                },
                new Student
                {
                    StudentId = 6,
                    StudentName = "Võ Thị K",
                    DateOfBirth = new DateTime(2001, 11, 22),
                    Address = "Huế",
                    TeacherId = 3
                },
                new Student
                {
                    StudentId = 7,
                    StudentName = "Đặng Văn L",
                    DateOfBirth = new DateTime(2002, 9, 18),
                    Address = "Bình Dương",
                    TeacherId = 4
                },
                new Student
                {
                    StudentId = 8,
                    StudentName = "Bùi Thị M",
                    DateOfBirth = new DateTime(2003, 1, 30),
                    Address = "Đồng Nai",
                    TeacherId = 4
                },
                new Student
                {
                    StudentId = 9,
                    StudentName = "Phan Văn N",
                    DateOfBirth = new DateTime(2002, 6, 12),
                    Address = "Quảng Nam",
                    TeacherId = 4
                },
                new Student
                {
                    StudentId = 10,
                    StudentName = "Ngô Thị O",
                    DateOfBirth = new DateTime(2001, 4, 8),
                    Address = "Nghệ An",
                    TeacherId = 1
                }
            );
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
}
