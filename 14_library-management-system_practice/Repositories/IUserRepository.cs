using _14_library_management_system_practice.Models;

namespace _14_library_management_system_practice.Repositories;

public interface IUserRepository
{
    public Task<User?> GetUserByUsernameAndPasswordAsync(string? username, string? password);
}
