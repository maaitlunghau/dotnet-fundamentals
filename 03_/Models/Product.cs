using System.ComponentModel.DataAnnotations.Schema;

namespace _03_;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [Column(TypeName = "decimal(10, 2)")]
    public float Price { get; set; }
    public int Quantity { get; set; }
    public int CateId { get; set; }

    // relationship
    public Category? Category { get; set; }
}
