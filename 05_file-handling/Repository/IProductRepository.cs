using _05_file_handling.Models;

namespace _05_file_handling.Repository;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetAllProductsAsync();
    public Task<Product?> GetProductByIdAsync(int? id);
    public Task CreateProductAsync(Product product);
    public Task UpdateProductAsync(Product product);
    public Task DeleteProductAsync(int? id);
}
