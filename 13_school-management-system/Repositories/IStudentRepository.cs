namespace _13_school_management_system.Repositories;

public interface IStudentRepository
{
    public Task<IEnumerable<Student>> GetAllStudentsAsync();
    public Task<Student?> GetStudentByIdAsync(int? id);
    public Task CreateStudentAsync(Student stu);
    public Task UpdateStudentAsync(Student stu);
    public Task DeleteStudentAsync(int? id);
}
