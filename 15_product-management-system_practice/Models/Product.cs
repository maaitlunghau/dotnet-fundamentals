using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _15_product_management_system_practice.Models;

public class Product
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Tên sản phẩm không được bỏ trống.")]
    public string? ProductName { get; set; }

    [Required(ErrorMessage = "Giá sản phẩm không được bỏ trống.")]
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Price { get; set; }

    public string? Image { get; set; }

    [NotMapped]
    public IFormFile? ImageHandling { get; set; }
}