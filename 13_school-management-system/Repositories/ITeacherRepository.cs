namespace _13_school_management_system.Repositories;

public interface ITeacherRepository
{
    public Task<IEnumerable<Teacher>> GetAllTeachersAsync();
    public Task<Teacher?> GetTeacherByIdAsync(int? id);
    public Task CreateTeacherAsync(Teacher t);
    public Task UpdateTeacherAsync(Teacher t);
    public Task DeleteTeacherAsync(int? id);
}
