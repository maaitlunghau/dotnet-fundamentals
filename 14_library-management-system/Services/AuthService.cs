using _14_library_management_system.Models;
using _14_library_management_system.Repositories;

namespace _14_library_management_system.Services;

public class AuthService : IAuthRepository
{
    private readonly DataContext _dbContext;
    public AuthService(DataContext dbContext) => _dbContext = dbContext;

    public Task Login()
    {
        throw new NotImplementedException();
    }
}
