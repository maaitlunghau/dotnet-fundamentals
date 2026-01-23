using _14_library_management_system_practice.Models;
using _14_library_management_system_practice.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _14_library_management_system_practice.Services;

public class BookService : IBookRepository
{
    private readonly DataContext _dbContext;
    public BookService(DataContext context) => _dbContext = context;


    public async Task<IEnumerable<Book>> getAllBooksAsync()
    {
        return await _dbContext.Books.ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int? id)
    {
        return await _dbContext.Books.FindAsync(id);
    }

    public async Task DeleteBookAsync(int? id)
    {
        var book = await _dbContext.Books.FindAsync(id);
        if (book != null)
        {
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}
