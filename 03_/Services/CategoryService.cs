using Microsoft.EntityFrameworkCore;

namespace _03_;

public class CategoryService : ICategoryRepository
{
    private readonly DataContext _context;

    public CategoryService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllCatesAsync()
    {
        var categories = await _context.Categories.ToListAsync();
        return categories;
    }

    public async Task AddCateAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCateAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}