using _13_school_management_system.Models;
using _13_school_management_system.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _13_school_management_system.Services;

public class StudentService : IStudentRepository
{
    private readonly DataContext _dbContext;
    public StudentService(DataContext context) => _dbContext = context;

    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        return await _dbContext.Students.ToListAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(int? id)
    {
        return await _dbContext.Students.FindAsync(id);
    }

    public async Task CreateStudentAsync(Student stu)
    {
        await _dbContext.Students.AddAsync(stu);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateStudentAsync(Student stu)
    {
        _dbContext.Students.Update(stu);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteStudentAsync(int? id)
    {
        var stu = await GetStudentByIdAsync(id);
        if (stu != null)
        {
            _dbContext.Students.Remove(stu);
            await _dbContext.SaveChangesAsync();
        }
    }
}
