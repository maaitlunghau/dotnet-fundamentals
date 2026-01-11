using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication1;

public class Customer
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public int? Age { get; set; }
    public bool Gender { get; set; }
    public ICollection<Order>? Orders { get; set; }
}
