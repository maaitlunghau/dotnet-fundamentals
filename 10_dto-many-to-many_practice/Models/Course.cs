using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _10_dto_many_to_many_practice.Models;

public class Course
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Tên khoá học không được bỏ trống!")]
    [StringLength(255, ErrorMessage = "Tên khoá học không được quá 255 ký tự")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Giá khoá học không được bỏ trống!")]
    [Column(TypeName = "decimal(10,2)")]
    [Range(0, 10000, ErrorMessage = "Giá tiền khoá học không được quá 10.000 đô")]
    public decimal? Price { get; set; }

    [Required(ErrorMessage = "Mô tả không được bỏ trống!")]
    [StringLength(100, ErrorMessage = "Mô tả không được quá 100 ký tự")]
    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    // relationship
    // ý nghĩa nói lên: 1 Course -> có thể chứa nhiều bảng ghi StudentCourse
    //      EX: Course A -> 15 StudentCourse
    //
    // dùng ICollection để:
    // -- giảm coupling
    // -- best practice (vì IEnumerable -> chỉ đọc, List -> phụ thuộc implementation)
    public ICollection<StudentCourse>? StudentCourses { get; set; }
}