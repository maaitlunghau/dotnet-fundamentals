using _14_library_management_system.Models;
using _14_library_management_system.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _14_library_management_system.Services;

public class BookService : IBookRepository
{
    private readonly DataContext _dbContext;
    public BookService(DataContext dbContext) => _dbContext = dbContext;


    public async Task<IEnumerable<Book>> GetAllBooksAsync()
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
            _dbContext.Remove(book);
            await _dbContext.SaveChangesAsync();
        }
    }

}