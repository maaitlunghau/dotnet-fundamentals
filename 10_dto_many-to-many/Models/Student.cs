using System.ComponentModel.DataAnnotations;
namespace _10_dto_many_to_many.Models;

public class Student
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Tên sinh viên không được bỏ trống!")]
    [StringLength(50, ErrorMessage = "Tên sinh viên phải có độ dài từ 3 đến 50 ký tự!")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Tuổi sinh viên không được bỏ trống!")]
    public int? Age { get; set; }

    // relationship
    public ICollection<StudentCourse>? StudentCourses { get; set; }
}
