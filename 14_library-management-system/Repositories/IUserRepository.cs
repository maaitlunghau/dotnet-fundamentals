using _14_library_management_system.Models;

namespace _14_library_management_system.Repositories;

public interface IUserRepository
{
    public Task<User?> GetUserByUsernameAndPasswordAsync(string? username, string? password);
}
