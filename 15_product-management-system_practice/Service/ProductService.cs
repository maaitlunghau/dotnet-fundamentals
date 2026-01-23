using _15_product_management_system_practice.Models;
using _15_product_management_system_practice.Repository;
using Microsoft.EntityFrameworkCore;

namespace _15_product_management_system_practice.Service;

public class ProductService : IProductRepository
{
    private readonly DataContext _dbContext;
    public ProductService(DataContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<Product?> GetProductByIdAsync(Guid? id)
    {
        return await _dbContext.Products.FindAsync(id);
    }

    public async Task CreateProductAsync(Product? product)
    {
        if (product is null)
            throw new ArgumentNullException(nameof(product));

        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(Guid? id)
    {
        var pro = await GetProductByIdAsync(id);
        if (pro != null)
        {
            _dbContext.Products.Remove(pro);
            await _dbContext.SaveChangesAsync();
        }
    }
}
