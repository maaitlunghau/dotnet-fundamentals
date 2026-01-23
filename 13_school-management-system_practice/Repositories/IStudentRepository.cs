using _13_school_management_system_practice.Models;

namespace _13_school_management_system_practice.Repositories;

public interface IStudentRepository
{
    public Task<IEnumerable<Student>> GetStudentsAsync();
    public Task CreateNewStudentAlongTeacher(Student? stu);
    public Task ChangeTeacherAsync(int? studentId, int? newTeacherId);
}
