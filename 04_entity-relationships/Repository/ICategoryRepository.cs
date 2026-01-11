
using _04_entity_relationships.Models;

namespace _04_entity_relationships.Repository;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryById(int? id);
    Task AddCategoryAsync(Category category);
    Task EditCategoryAsync(Category category);
    Task DeleteCategoryAsync(int id);
}
