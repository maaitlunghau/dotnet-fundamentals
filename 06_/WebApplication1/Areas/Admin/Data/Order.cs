using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication1;

public class Order
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
    [Required]
    public int? Quantity { get; set; }
    public DateTime OrderDate { get; set; }

    public Customer? Customer { get; set; }
    public int CusId { get; set; }
}
