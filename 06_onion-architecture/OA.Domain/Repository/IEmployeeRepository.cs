using OA.Domain.Model;

namespace OA.Domain.Repository;

public interface IEmployeeRepository
{
    public Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    public Task<Employee?> GetEmployeeByIdAsync(Guid? id);
    public Task CreateEmployeeAsync(Employee employee);
    public Task UpdateEmployeeAsync(Employee employee);
    public Task DeleteEmployeeAsync(Guid? id);
}
