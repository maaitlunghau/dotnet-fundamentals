namespace _03_;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCatesAsync();
    Task AddCateAsync(Category category);
    Task UpdateCateAsync(Category category);
    Task DeleteCateAsync(int id);
}
