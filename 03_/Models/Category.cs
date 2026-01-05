using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _03_;

public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool Status { get; set; }

    // relationship
    public ICollection<Product>? Products { get; set; } // navigation property
    // 1 Category -> has N Products
}
