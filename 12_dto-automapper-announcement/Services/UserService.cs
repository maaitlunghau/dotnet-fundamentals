using _12_dto_automapper_announcement.Models;
using _12_dto_automapper_announcement.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _12_dto_automapper_announcement.Services;

public class UserService : IUserRepository
{
    private readonly DataContext _dbContext;
    public UserService(DataContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(Guid? id)
    {
        return await _dbContext.Users.FindAsync(id);
    }

    public async Task<User?> GetUserLoginAsync(string? email, string? password)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        if (user is null) return null!;

        return user;
    }

    public async Task CreateUserAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteUserAsync(Guid? id)
    {
        var user = _dbContext.Users.Find(id);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
