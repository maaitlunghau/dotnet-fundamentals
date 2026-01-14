using _05_file_handling_practice.Models;
using _05_file_handling_practice.Repository;
using Microsoft.EntityFrameworkCore;

namespace _05_file_handling_practice.Services;

public class ProductService : IProductRepository
{
    private readonly DataContext _dbContext;
    public ProductService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int? id)
    {
        return await _dbContext.Products.FindAsync(id);
    }
    public async Task AddProductAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Product product)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
    }
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
