using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.Domain.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên nhân viên không được bỏ trống!")]
    [StringLength(maximumLength: 100, ErrorMessage = "Tên nhân viên chỉ tối đa 100 ký tự")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Lương nhân viên không được bỏ trống!")]
    [Column(TypeName = "decimal(10,2)")]
    [Range(10, 1000, ErrorMessage = "Lương nhân viên phải tầm 10 - 1000 đô!")]
    public decimal Salary { get; set; }

    [Required(ErrorMessage = "Tuổi nhân viên không được bỏ trống!")]
    [Range(18, 65, ErrorMessage = "Tuổi chỉ từ 18 đến 50 tuổi!")]
    public int Age { get; set; }
}
