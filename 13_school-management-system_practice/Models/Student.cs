using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _13_school_management_system_practice.Attribute;

namespace _13_school_management_system_practice.Models;

public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên sinh viên không được phép bỏ trống!")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "Tên sinh viên phải từ 3 đến 60 kí tự.")]
    public string? StudentName { get; set; }

    [Required(ErrorMessage = "Ngày sinh không được phép bỏ trống!")]
    [DataType(DataType.Date)]
    [Column(TypeName = "date")]
    [PastDate]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Địa chỉ không được phép bỏ trống!")]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "Địa chỉ sinh viên phải từ 3 đến 60 kí tự.")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn giáo viên phụ trách cho sinh viên.")]
    [ForeignKey("Teacher")]
    public int TeacherId { get; set; }

    public Teacher? Teacher { get; set; }
}
