using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _08_unit_of_work_practice.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    [Column(TypeName = "decimal(10, 2)")]
    [Range(0, 10000)]
    public decimal Price { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    [StringLength(
        500,
        MinimumLength = 10,
        ErrorMessage = "Description must be between 10 to 500 characters"
    )]
    public string? Description { get; set; }
}
