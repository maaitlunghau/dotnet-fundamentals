using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _04_entity_relationships.Models;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool Status { get; set; } = false;

    // relationship
    public ICollection<Product>? Product { get; set; }
    // 1 Category -> N Products
}
