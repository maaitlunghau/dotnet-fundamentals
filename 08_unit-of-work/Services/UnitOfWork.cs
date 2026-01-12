using _08_unit_of_work.Models;
using _08_unit_of_work.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace _08_unit_of_work.Services;

public class UnitOfWork : IUnitOfWork
{
    private IDbContextTransaction _transaction;
    private readonly DataContext _dbContext;
    private IProductRepository _productRepository;
    private IOrderRepository _orderRepository;
    public UnitOfWork(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    // lazy initialization (?)
    // ??= : Nullish Coalescing Assignment
    public IProductRepository Products => _productRepository ??= new ProductService(_dbContext);

    public IOrderRepository Orders => _orderRepository ??= new OrderService(_dbContext);


    public async Task BeginTransactionAsync()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await _transaction.CommitAsync();
    }

    public async Task<bool> CompleteAsync()
    {
        try
        {
            await _transaction.CommitAsync();
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            await RollBackAsync();
            return false;
        }
    }

    public async Task RollBackAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
        }
    }
}
