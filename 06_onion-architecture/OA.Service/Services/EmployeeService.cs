using OA.Domain.Model;
using OA.Domain.Repository;

namespace OA.Service.Services;

public class EmployeeService
{
    private readonly IEmployeeRepository _repo;
    public EmployeeService(IEmployeeRepository repo) => _repo = repo;

    public async Task<IEnumerable<Employee>> GetAll()
        => await _repo.GetAllEmployeesAsync();

    public async Task<Employee?> GetById(Guid id)
        => await _repo.GetEmployeeByIdAsync(id);

    public async Task Create(Employee emp)
        => await _repo.CreateEmployeeAsync(emp);

    public async Task Update(Employee emp)
        => await _repo.UpdateEmployeeAsync(emp);

    public async Task Delete(Guid id)
        => await _repo.DeleteEmployeeAsync(id);
}
