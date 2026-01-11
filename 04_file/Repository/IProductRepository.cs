namespace _04_file;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetOneProductAsync(int productId);
    Task CreateProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(int productId);
}
