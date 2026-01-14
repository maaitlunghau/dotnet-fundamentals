using _05_file_handling_practice.Models;
namespace _05_file_handling_practice.Repository;

public interface IProductRepository
{
    /// <summary>
/// Retrieves all products from the repository as a collection.
/// </summary>
/// <returns>An IEnumerable of Product containing all products; the collection may be empty.</returns>
public Task<IEnumerable<Product>> GetAllProductsAsync();
    /// <summary>
/// Retrieves a product by its identifier.
/// </summary>
/// <param name="id">The product identifier to retrieve; may be null.</param>
/// <returns>The product with the specified identifier, or `null` if no matching product exists or if <paramref name="id"/> is null.</returns>
public Task<Product?> GetProductByIdAsync(int? id);
    /// <summary>
/// Adds a new product to the repository.
/// </summary>
/// <param name="product">The product to add.</param>
/// <returns>A task that completes when the product has been added.</returns>
public Task AddProductAsync(Product product);
    /// <summary>
/// Updates an existing product using the values from the provided Product instance.
/// </summary>
/// <param name="product">The Product containing updated values; its identifier is used to locate the product to update.</param>
public Task UpdateProductAsync(Product product);
    /// <summary>
/// Deletes the product with the specified identifier.
/// </summary>
/// <param name="id">The identifier of the product to delete, or null if no id is provided.</param>
public Task DeleteProductAsync(int? id);
}