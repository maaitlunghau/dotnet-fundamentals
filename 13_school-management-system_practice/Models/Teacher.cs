using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13_school_management_system_practice.Models;

public class Teacher
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên giảng viên không được phép bỏ trống!")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "Tên giảng viên phải từ 3 đến 60 kí tự.")]
    public string? TeacherName { get; set; }

    [StringLength(50, ErrorMessage = "Ban giảng viên không được quá 50 kí tự!")]
    public string? Department { get; set; }

    [Required(ErrorMessage = "Email giảng viên không được phép bỏ trống!")]
    [EmailAddress(ErrorMessage = "Email phải đúng định dạng.")]
    [StringLength(40, ErrorMessage = "Email giảng viên không được quá 50 kí tự!")]
    public string? Email { get; set; }

    public ICollection<Student>? Students { get; set; }
}
