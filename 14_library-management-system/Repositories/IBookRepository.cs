using _14_library_management_system.Models;

namespace _14_library_management_system.Repositories;

public interface IBookRepository
{
    public Task<IEnumerable<Book>> GetAllBooksAsync();
    public Task<Book?> GetBookByIdAsync(int? id);
    public Task DeleteBookAsync(int? id);
}
