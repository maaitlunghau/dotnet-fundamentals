using _13__school_management_system.Models;
using _13__school_management_system.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _13__school_management_system.Services;

public class TeacherService : ITeacherRepository
{
    private readonly DataContext _dbContext;
    public TeacherService(DataContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
    {
        return await _dbContext.Teachers.ToListAsync();
    }

    public async Task<Teacher?> GetTeacherByIdAsync(Guid? id)
    {
        return await _dbContext.Teachers.FindAsync(id);
    }

    public async Task CreateNewTeacherAsync(Teacher teacher)
    {
        await _dbContext.Teachers.AddAsync(teacher);
        await _dbContext.SaveChangesAsync();
    }


    public async Task EditTeacherAsync(Teacher teacher)
    {
        _dbContext.Teachers.Update(teacher);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteTeacherAsync(Guid? id)
    {
        var teacher = await _dbContext.Teachers.FindAsync(id);
        if (teacher != null)
        {
            _dbContext.Teachers.Remove(teacher);
            await _dbContext.SaveChangesAsync();
        }
    }
}
