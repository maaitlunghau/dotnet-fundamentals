using _08_unit_of_work_practice.Models;
using _08_unit_of_work_practice.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _08_unit_of_work_practice.Services;

public class OrderService : IOrderRepository
{
    private readonly DataContext _dbContext;
    public OrderService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await _dbContext.Orders.Include(o => o.Product).ToListAsync();
    }

    public async Task<Order?> GetOrderByIdAsync(int? id)
    {
        return await _dbContext.Orders.FindAsync(id);
    }

    public async Task AddOrderAsync(Order order)
    {
        await _dbContext.Orders.AddAsync(order);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateOrderAsync(Order order)
    {
        _dbContext.Orders.Update(order);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(int? id)
    {
        var product = await GetOrderByIdAsync(id);
        if (product != null)
        {
            _dbContext.Orders.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
