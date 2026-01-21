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
    [StringLength(60, MinimumLength = 3, ErrorMessage = "Tên sinh viên không được quá 60 kí tự!")]
    public string? StudentName { get; set; }

    [Required(ErrorMessage = "Ngày sinh không được bỏ trống!")]
    [Column(TypeName = "date")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? DateOfBirth { get; set; }

    [Required(ErrorMessage = "Địa chỉ sinh viên không được bỏ trống!")]
    [StringLength(100, MinimumLength = 10, ErrorMessage = "Địa chỉ phải từ 10 đến 100 kí tự!")]
    public string? Address { get; set; }

    public Teacher? Teacher { get; set; }
}
