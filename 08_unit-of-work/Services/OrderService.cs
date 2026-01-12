using _08_unit_of_work.Models;
using _08_unit_of_work.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _08_unit_of_work.Services;

public class OrderService : IOrderRepository
{
    private readonly DataContext _dbContext;
    public OrderService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddOrderAsync(Order order)
    {
        await _dbContext.Orders.AddAsync(order);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        var orders = await _dbContext.Orders.Include(o => o.Product).ToListAsync();
        return orders;
    }
}
