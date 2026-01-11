using _02_layered_architecture.Models;
using _02_layered_architecture.Repository;
using Microsoft.EntityFrameworkCore;

namespace _02_layered_architecture.Services;

public class ProductService : IProductRepository
{
    private readonly DataContext _dbContext;
    public ProductService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var products = await _dbContext.Products.ToListAsync();
        return products;
    }

    public async Task<Product?> GetProByIdAsync(int? id)
    {
        var product = await _dbContext.Products.FindAsync(id);
        return product;
    }

    public async Task AddProAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task EditProAsync(Product product)
    {
        _dbContext.Products.Update(product);
    }

    public async Task DeleteProAsync(int id)
    {
        var product = await GetProByIdAsync(id);
        if (product != null)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}