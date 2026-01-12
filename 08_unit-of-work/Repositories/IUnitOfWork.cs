namespace _08_unit_of_work.Repositories;

public interface IUnitOfWork
{
    IProductRepository Products { get; }
    IOrderRepository Orders { get; }

    Task CommitAsync();
    Task<bool> CompleteAsync();
    Task RollBackAsync();
    Task BeginTransactionAsync();
}
