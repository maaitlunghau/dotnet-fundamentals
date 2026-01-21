using _13__school_management_system.Models;
using _13__school_management_system.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _13__school_management_system.Services;

public class StudentService : IStudentRepository
{
    private readonly DataContext _dbContext;
    public StudentService(DataContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
    {
        return await _dbContext.Students.ToListAsync();
    }

    public async Task<Student?> GetStudentByIdAsync(Guid? id)
    {
        return await _dbContext.Students.FindAsync(id);
    }

    public async Task CreateNewStudentAsync(Student stu)
    {
        await _dbContext.Students.AddAsync(stu);
        await _dbContext.SaveChangesAsync();
    }


    public async Task EditStudentAsync(Student stu)
    {
        _dbContext.Students.Update(stu);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteStudentAsync(Guid? id)
    {
        var stu = await _dbContext.Students.FindAsync(id);
        if (stu != null)
        {
            _dbContext.Students.Remove(stu);
            await _dbContext.SaveChangesAsync();
        }
    }
}
