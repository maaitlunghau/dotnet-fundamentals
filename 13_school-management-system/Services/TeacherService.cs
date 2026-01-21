using _13_school_management_system.Models;
using _13_school_management_system.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _13_school_management_system.Services;

public class TeacherService : ITeacherRepository
{
    private readonly DataContext _dbContext;
    public TeacherService(DataContext context) => _dbContext = context;

    public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
    {
        return await _dbContext.Teachers.ToListAsync();
    }

    public async Task<Teacher?> GetTeacherByIdAsync(int? id)
    {
        return await _dbContext.Teachers
            .Include(t => t.Students)
            .FirstOrDefaultAsync(t => t.TeacherId == id);
    }

    public async Task CreateTeacherAsync(Teacher teacher)
    {
        await _dbContext.Teachers.AddAsync(teacher);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateTeacherAsync(Teacher teacher)
    {
        _dbContext.Teachers.Update(teacher);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteTeacherAsync(int? id)
    {
        var teacher = await GetTeacherByIdAsync(id);
        if (teacher != null)
        {
            _dbContext.Teachers.Remove(teacher);
            await _dbContext.SaveChangesAsync();
        }
    }
}
