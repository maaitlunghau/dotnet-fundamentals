using System.ComponentModel.DataAnnotations;
namespace _10_dto_many_to_many.Models;

public class Course
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Tên khoá học không được bỏ trống!")]
    [StringLength(255, ErrorMessage = "Độ dài tên khoá học phải từ 6-255 ký tự!")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Giá khoá học không được bỏ trống!")]
    [Range(0, 100000, ErrorMessage = "Giá khoá học phải là số dương!")]
    public double? Price { get; set; }

    // relationship
    public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}
