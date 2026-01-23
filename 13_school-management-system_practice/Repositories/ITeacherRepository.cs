using _13_school_management_system_practice.Models;

namespace _13_school_management_system_practice.Repositories;

public interface ITeacherRepository
{
    public Task<IEnumerable<Teacher>> GetAllTeachersAsync();
    public Task<Teacher?> GetTeacherByIdAsync(int? id);
    public Task CreateNewTeacherAsync(Teacher? t);
    public Task UpdateTeacherAsync(Teacher? t);
}
