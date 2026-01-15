using System.ComponentModel.DataAnnotations;

namespace _10_dto_many_to_many_practice.Models;

public class Student
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Tên sinh viên không được bỏ trống!")]
    [StringLength(50, ErrorMessage = "Tên sinh viên không được quá 50 ký tự")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Tuổi sinh viên không được bỏ trống!")]
    public int? Age { get; set; }

    // relationship
    // ý nghĩa nói lên: 1 Student -> có thể chứa nhiều bảng ghi / dữ liệu StudentCourse
    //      EX: Student A -> 3 StudentCourse
    //          Student B -> 1 StudnetCourse 
    // 
    // dùng ICollection để:
    // -- giảm coupling
    // -- best practice (vì IEnumerable -> chỉ đọc, List -> phụ thuộc implementation)
    public ICollection<StudentCourse>? StudentCourses { get; set; }
}