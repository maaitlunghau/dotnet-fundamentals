using _15_product_management_system.Models;

namespace _15_product_management_system.Repository;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetAllProductsAsync();
    public Task<Product?> GetProductByIdAsync(Guid? id);
    public Task CreateProductAsync(Product? product);
    public Task UpdateProductAsync(Product? product);
    public Task DeleteProductAsync(Guid? id);
}