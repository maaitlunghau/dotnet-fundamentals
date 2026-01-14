using _05_file_handling_practice.Models;
using _05_file_handling_practice.Repository;
using Microsoft.EntityFrameworkCore;

namespace _05_file_handling_practice.Services;

public class ProductService : IProductRepository
{
    private readonly DataContext _dbContext;
    /// <summary>
    /// Initializes a new instance of ProductService using the provided data context.
    /// </summary>
    /// <param name="dbContext">The DataContext used for accessing and persisting Product entities.</param>
    public ProductService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Retrieve all Product entities from the database.
    /// </summary>
    /// <returns>An enumerable containing all Product entities.</returns>
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    /// <summary>
    /// Retrieves the product with the specified primary key.
    /// </summary>
    /// <param name="id">The product's primary key; may be <c>null</c>.</param>
    /// <returns>The <see cref="Product"/> with the given id, or <c>null</c> if not found or if <paramref name="id"/> is <c>null</c>.</returns>
    public async Task<Product?> GetProductByIdAsync(int? id)
    {
        return await _dbContext.Products.FindAsync(id);
    }
    /// <summary>
    /// Adds the specified product to the data store and saves the change.
    /// </summary>
    /// <param name="product">The product entity to add to the database.</param>
    public async Task AddProductAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Updates an existing Product in the database with the provided entity's values.
    /// </summary>
    /// <param name="product">The Product entity containing updated values; its key identifies which record to update.</param>
    public async Task UpdateProductAsync(Product product)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
    }
    /// <summary>
    /// Deletes the product with the specified id if it exists in the data store.
    /// </summary>
    /// <param name="id">The primary key of the product to delete; if <c>null</c> or no matching product is found, the method completes without action.</param>
    public async Task DeleteProductAsync(int? id)
    {
        var product = await _dbContext.Products.FindAsync(id);
        if (product != null)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}