using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _05_file_handling_practice.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Tên sản phẩm không được để trống!")]
    [StringLength(maximumLength: 100, ErrorMessage = "Tên sản phẩm chỉ tối đa 100 ký tự!")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Giá sản phẩm không được để trống!")]
    [Column(TypeName = "decimal(10,2)")]
    [Range(1, 10000, ErrorMessage = "Giá sản phẩm phải từ 1 đến 10.000 đô la Mỹ!")]
    public decimal? Price { get; set; }

    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    [Display(Name = "Ảnh sản phẩm")]
    public string? ImageUrl { get; set; }

    [NotMapped]
    public IFormFile? Image { get; set; }
}
