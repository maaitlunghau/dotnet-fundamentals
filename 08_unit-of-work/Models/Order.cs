using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _08_unit_of_work.Models;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int ProductId { get; set; } // biết được sản phẩm nào
    public int Quantity { get; set; }
    public double TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public Product? Product { get; set; }
    // Products: nhiều sản phẩm (1 Order -> N Product)
    // nhưng đang demo quan hệ 1 -> 1 thôi

    // lấy quan hệ cho nhanh hơn (tối ưu tốc độ)
}