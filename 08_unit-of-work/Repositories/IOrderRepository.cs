using _08_unit_of_work.Models;

namespace _08_unit_of_work.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task AddOrderAsync(Order order);
}
