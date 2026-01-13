using _08_unit_of_work_practice.Models;

namespace _08_unit_of_work_practice.Repositories;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetAllProductAsync();
    public Task<Product?> GetProductByIdAsync(int? id);
    public Task AddProductAsync(Product product);
    public Task UpdateProductAsync(Product product);
    public Task DeleteProductAsync(int? id);
}
