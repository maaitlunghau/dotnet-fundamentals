using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _13_school_management_system;

public class Teacher
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TeacherId { get; set; }

    [Required]
    [StringLength(60, ErrorMessage = "Tên giáo viên không được nhiều hơn 60 kí tự!")]
    public string? TeacherName { get; set; }

    [Required]
    [StringLength(40, ErrorMessage = "Email giáo viên không nhiều hơn 40 kí tự!")]
    public string? Email { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Khoa của giáo viên không được nhiều hơn 50 kí tự!")]
    public string? Department { get; set; }

    public ICollection<Student> Students { get; set; } = new List<Student>();
}
