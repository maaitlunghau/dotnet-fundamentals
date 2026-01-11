using _04_entity_relationships.Models;

namespace _04_entity_relationships.Repository;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();

    Task<Product?> GetProByIdAsync(int? id);

    Task AddProAsync(Product product);
    Task EditProAsync(Product product);
    Task DeleteProAsync(int id);
}
