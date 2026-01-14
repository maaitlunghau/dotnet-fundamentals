using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.Domain.Model;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên nhân viên không được bỏ trống!")]
    [StringLength(50, ErrorMessage = "Tên nhân viên không được vượt quá 50 ký tự!")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Lương nhân viên không được bỏ trống")]
    [Range(10, 10000, ErrorMessage = "Lương nhân viên phải từ 10 - 10.000 đô la!")]
    public double? Salary { get; set; }

    [Range(18, 65, ErrorMessage = "Nhân viên phải từ 18 đến 65 tuổi!")]
    [Required(ErrorMessage = "Tuổi nhân viên không được bỏ trống!")]
    public int Age { get; set; }
}
