using _13__school_management_system.Models;

namespace _13__school_management_system.Repositories;

public interface IStudentRepository
{
    public Task<IEnumerable<Student>> GetAllStudentsAsync();
    public Task<Student?> GetStudentByIdAsync(Guid? id);
    public Task CreateNewStudentAsync(Student student);
    public Task EditStudentAsync(Student student);
    public Task DeleteStudentAsync(Guid? id);
}
