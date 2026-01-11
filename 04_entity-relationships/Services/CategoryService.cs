using _04_entity_relationships.Models;
using _04_entity_relationships.Repository;
using Microsoft.EntityFrameworkCore;

namespace _04_entity_relationships.Services;

public class CategoryService : ICategoryRepository
{
    private readonly DataContext _dbContext;
    public CategoryService(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        var categories = await _dbContext.Categories.ToListAsync();
        return categories;
    }

    public async Task<Category?> GetCategoryById(int? id)
    {
        var category = await _dbContext.Categories.FindAsync(id);
        return category;
    }

    public async Task AddCategoryAsync(Category category)
    {
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task EditCategoryAsync(Category category)
    {
        _dbContext.Categories.Update(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await GetCategoryById(id);
        if (category != null)
        {
            _dbContext.Remove(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
