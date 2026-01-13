namespace _08_unit_of_work_practice.Repositories;

public interface IUnitOfWork
{
    IProductRepository ProductRepository { get; }
    IOrderRepository OrderRepository { get; }

    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
    Task<bool> CompleteAsync();
}
