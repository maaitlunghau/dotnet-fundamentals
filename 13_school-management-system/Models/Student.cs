using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13_school_management_system;

public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int StudentId { get; set; }

    [ForeignKey("TeacherId")]
    public int TeacherId { get; set; }

    [Required(ErrorMessage = "Tên sinh viên không được phép bỏ trống!")]
    [StringLength(60, ErrorMessage = "Tên sinh viên không được quá 60 kí tự!")]
    public string? StudentName { get; set; }

    [Required(ErrorMessage = "Ngày tháng năm sinh sinh viên không được bỏ trống!")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Địa chỉ sinh viên không được bỏ trống!")]
    [StringLength(100, ErrorMessage = "Địa chỉ không được quá 100 kí tự!")]
    public string? Address { get; set; }

    public Teacher? Teacher { get; set; }
}
