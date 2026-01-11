using Microsoft.EntityFrameworkCore;

namespace _04_file;

public class ProductService : IProductRepository
{
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetOneProductAsync(int productId)
    {
        var product = await _context.Products.FindAsync(productId);
        return product!;
    }

    public async Task CreateProductAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    // check lại file của thầy
    // nhớ thầy code delete kiểu khác
    public async Task DeleteProductAsync(int productId)
    {
        var product = await _context.Products.FindAsync(productId);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
