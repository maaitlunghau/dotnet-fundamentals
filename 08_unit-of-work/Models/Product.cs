using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _08_unit_of_work.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    // double: hơi cao, giá thì nên chính xác hơn tầm decimal
    public int Quantity { get; set; }
}
