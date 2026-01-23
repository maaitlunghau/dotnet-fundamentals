
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _16_exam.Models;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Họ của công nhân không được bỏ trống!")]
    [StringLength(20, ErrorMessage = "Họ của công nhân không được quá 20 kí tự!")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Tên của công nhân không được bỏ trống!")]
    [StringLength(20, ErrorMessage = "Tên của công nhân không được quá 20 kí tự!")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Ngày sinh không được phép bỏ trống!")]
    public DateTime? BirthDate { get; set; }

    [Required(ErrorMessage = "Kỹ năng của công nhân không được bỏ trống!")]
    [StringLength(100, ErrorMessage = "Kỹ năng không được quá 100 kí tự!")]
    public string? Skills { get; set; }

    [StringLength(150, ErrorMessage = "Đường dẫn ảnh không được quá 150 kí tự!")]
    public string? Photo { get; set; }

    [NotMapped]
    public IFormFile? PhotoHandling { get; set; }
}
