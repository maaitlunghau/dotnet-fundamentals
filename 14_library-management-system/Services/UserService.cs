using _14_library_management_system.Models;
using _14_library_management_system.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _14_library_management_system.Services;

public class UserService : IUserRepository
{
    private readonly DataContext _dbContext;
    public UserService(DataContext context) => _dbContext = context;


    public async Task<User?> GetUserByUsernameAndPasswordAsync(string? username, string? password)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u =>
            u.Username == username &&
            u.Password == password
        );
    }
}
