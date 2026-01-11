using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02_layered_architecture.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    [Range(100, 1000, ErrorMessage = "Price must be between 100 - 1000 ($)")]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }
}
