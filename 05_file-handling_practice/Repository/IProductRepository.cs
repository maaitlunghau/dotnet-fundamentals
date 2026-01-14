using _05_file_handling_practice.Models;
namespace _05_file_handling_practice.Repository;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetAllProductsAsync();
    public Task<Product?> GetProductByIdAsync(int? id);
    public Task AddProductAsync(Product product);
    public Task UpdateProductAsync(Product product);
    public Task DeleteProductAsync(int? id);
}
