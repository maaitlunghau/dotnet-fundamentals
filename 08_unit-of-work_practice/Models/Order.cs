using _08_unit_of_work_practice.Models;

namespace _08_unit_of_work_practice;

public class Order
{
    public int Id { get; set; }
    public int ProductId { get; set; } // biết được Order này có Product nào
    public int Quantity { get; set; }
    public double TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }

    // giúp lấy quan hệ nhanh hơn
    public Product? Product { get; set; }
    // Product: 1 Order -> 1 Product
    // if Products: 1 Orders -> N Products
}
