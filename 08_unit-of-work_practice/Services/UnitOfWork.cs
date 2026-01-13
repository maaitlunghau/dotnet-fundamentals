using _08_unit_of_work_practice.Models;
using _08_unit_of_work_practice.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace _08_unit_of_work_practice.Services;

public class UnitOfWork : IUnitOfWork
{
    private IDbContextTransaction? _transaction;
    private DataContext _dbContext;
    private IProductRepository? _productRepository;
    private IOrderRepository? _orderRepository;

    // constructor
    public UnitOfWork(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    // lazy initialization: chỉ tạo repo khi cần thiết thôi, chứ kh phải lúc nào cũng tạo sẵn
    //                      _productRepository hay _orderRepository chưa tạo (null) -> tạo mới cùng _dbContext
    //                      -> đảm bảo được _transaction và _repo đang sử dụng cùng _dbContext
    //
    // nếu kh lazy initilize thì tạo chung trong constructor:
    // 
    //      public UnitOfWork(DataContext dbContext)
    //      {
    //          _dbContext = dbContext;
    //          _productRepository = new ProductService(dbContext);
    //          _orderRepository = new OrderService(dbContext);
    //      }
    //
    // Tóm lại:
    // Repository làm việc với từng Entity, UnitOfWork (UoW) quản lý transaction
    // và đảm bảo các repository dùng chung 1 _dbContẽt.
    // Khi sử dụng UnitOfWork, kh nên inject repository trực tiếp từ DI container, mà chỉ inject UnitOfWork

    public IProductRepository ProductRepository
        => _productRepository ??= new ProductService(_dbContext);

    public IOrderRepository OrderRepository
        => _orderRepository ??= new OrderService(_dbContext);

    public async Task BeginTransactionAsync()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
        }
    }

    public async Task<bool> CompleteAsync()
    {
        try
        {
            await CommitAsync();
            await _dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            await RollbackAsync();
            return false;
        }
    }

    public async Task RollbackAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
        }
    }
}
