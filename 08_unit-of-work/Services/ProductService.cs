using System.Reflection.Metadata.Ecma335;
using _08_unit_of_work.Models;
using _08_unit_of_work.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _08_unit_of_work.Services;

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

    public async Task<Product?> GetProductByIdAsync(int? id)
    {
        var product = await _dbContext.Products.FindAsync(id);
        return product;
    }

    public async Task AddProduct(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteProduct(int id)
    {
        var product = await _dbContext.Products.FindAsync(id);
        if (product != null)
        {
            _dbContext.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateProduct(Product product)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
    }
}
