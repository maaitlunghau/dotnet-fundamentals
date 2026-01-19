using _13__school_management_system.Models;

namespace _13__school_management_system.Repositories;

public interface ITeacherRepository
{
    public Task<IEnumerable<Teacher>> GetAllTeachersAsync();
    public Task<Teacher?> GetTeacherByIdAsync(Guid? id);
    public Task CreateNewTeacherAsync(Teacher teacher);
    public Task EditTeacherAsync(Teacher teacher);
    public Task DeleteTeacherAsync(Guid? id);
}
