using _13_school_management_system_practice.Models;
using _13_school_management_system_practice.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _13_school_management_system_practice.Services;

public class StudentService : IStudentRepository
{
    private readonly DataContext _dbContext;
    public StudentService(DataContext context) => _dbContext = context;


    public async Task<IEnumerable<Student>> GetStudentsAsync()
    {
        return await _dbContext.Students
            .Include(stu => stu.Teacher!)
            .ToListAsync();
    }

    public async Task CreateNewStudentAlongTeacher(Student? stu)
    {
        if (stu is null)
            throw new ArgumentNullException(nameof(stu), "Sinh viên không được rỗng!");

        await _dbContext.Students.AddAsync(stu);
        await _dbContext.SaveChangesAsync();
    }
}
