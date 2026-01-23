using _14_library_management_system_practice.Models;
using _14_library_management_system_practice.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _14_library_management_system_practice.Services;

public class UserService : IUserRepository
{
    private readonly DataContext _dbContext;
    public UserService(DataContext dbContext) => _dbContext = dbContext;

    public async Task<User?> GetUserByUsernameAndPasswordAsync(string? username, string? password)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u =>
            u.Username == username &&
            u.Password == password
        );
    }
}
