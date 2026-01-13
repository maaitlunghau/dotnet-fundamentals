namespace _08_unit_of_work_practice.Repositories;

public interface IOrderRepository
{
    public Task<IEnumerable<Order>> GetAllOrdersAsync();
    public Task<Order?> GetOrderByIdAsync(int? id);
    public Task AddOrderAsync(Order order);
    public Task UpdateOrderAsync(Order order);
    public Task DeleteOrderAsync(int? id);
}
