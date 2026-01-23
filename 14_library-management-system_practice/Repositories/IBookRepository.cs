using _14_library_management_system_practice.Models;

namespace _14_library_management_system_practice.Repositories;

public interface IBookRepository
{
    public Task<IEnumerable<Book>> getAllBooksAsync();
    public Task DeleteBookAsync(int? id);
}
