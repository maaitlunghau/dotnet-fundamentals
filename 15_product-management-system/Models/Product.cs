using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace _15_product_management_system.Models;

public class Product
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Product name is required.")]
    public string? ProductName { get; set; }

    [Required(ErrorMessage = "Product price is required.")]
    [Column(TypeName = "decimal(10,2)")]
    public decimal? Price { get; set; }

    [Required(ErrorMessage = "Image is required.")]
    public string? Image { get; set; }

    [NotMapped]
    [Required(ErrorMessage = "Please select an image.")]
    public IFormFile? ImageHandling { get; set; }
}
