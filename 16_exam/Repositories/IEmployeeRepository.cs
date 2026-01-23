using _16_exam.Models;

namespace _16_exam.Repositories;

public interface IEmployeeRepository
{
    public Task<IEnumerable<Employee>> GetAllEmployeeAsync();
    public Task<Employee?> GetEmployeeByIdAsync(int? id);
    public Task CreateNewEmployeeAsync(Employee? employee);
    public Task UpdateEmployeeAsync(Employee? employee);
    public Task DeleteEmployeeAsync(int? id);
}
