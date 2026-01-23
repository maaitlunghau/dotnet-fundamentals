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

    public async Task ChangeTeacherAsync(int? studentId, int? newTeacherId)
    {
        if (studentId == null || newTeacherId == null)
            throw new ArgumentNullException("StudentId hoặc NewTeacherId không được null");

        var student = await _dbContext.Students
            .FirstOrDefaultAsync(s => s.Id == studentId);
        if (student == null)
            throw new Exception("Không tìm thấy sinh viên");

        var teacherExists = await _dbContext.Teachers
            .AnyAsync(t => t.Id == newTeacherId);
        if (!teacherExists)
            throw new Exception("Giảng viên mới không tồn tại");

        student.TeacherId = newTeacherId.Value;

        await _dbContext.SaveChangesAsync();
    }
}
