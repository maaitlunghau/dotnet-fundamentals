using _12_dto_automapper_announcement.Models;
namespace _12_dto_automapper_announcement.Repositories;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetAllUsersAsync();
    public Task<User?> GetUserByIdAsync(Guid? id);
    public Task CreateUserAsync(User user);
    public Task UpdateUserAsync(User user);
    public Task DeleteUserAsync(Guid? id);
}
