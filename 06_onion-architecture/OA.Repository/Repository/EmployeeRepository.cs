using Microsoft.EntityFrameworkCore;
using OA.Domain.Model;
using OA.Domain.Repository;
using OA.Repository.Data;

namespace OA.Repository.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DataContext _dbContext;
    public EmployeeRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _dbContext.Employees.ToListAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(Guid? id)
    {
        return await _dbContext.Employees.FindAsync(id);
    }

    public async Task CreateEmployeeAsync(Employee employee)
    {
        await _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        _dbContext.Employees.Update(employee);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(Guid? id)
    {
        var emp = await GetEmployeeByIdAsync(id);
        if (emp != null)
        {
            _dbContext.Employees.Remove(emp);
            await _dbContext.SaveChangesAsync();
        }
    }
}
