using _13_school_management_system_practice.Models;
using _13_school_management_system_practice.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _13_school_management_system_practice.Services;

public class TeacherService : ITeacherRepository
{
    private readonly DataContext _dbContext;
    public TeacherService(DataContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
    {
        return await _dbContext.Teachers
            .Include(t => t.Students)
            .ToListAsync();
    }

    public async Task<Teacher?> GetTeacherByIdAsync(int? id)
    {
        return await _dbContext.Teachers
            .Include(t => t.Students)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task CreateNewTeacherAsync(Teacher? t)
    {
        if (t == null)
            throw new ArgumentNullException(nameof(t), "Teacher cannot be null");

        await _dbContext.Teachers.AddAsync(t);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateTeacherAsync(Teacher? t)
    {
        if (t == null)
            throw new ArgumentNullException(nameof(t), "Teacher cannot be null");

        _dbContext.Teachers.Update(t);
        await _dbContext.SaveChangesAsync();
    }
}
