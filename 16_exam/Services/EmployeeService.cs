using _16_exam.Models;
using _16_exam.Repositories;
using Microsoft.EntityFrameworkCore;

namespace _16_exam.Services;

public class EmployeeService : IEmployeeRepository
{
    private readonly DataContext _dbContext;
    public EmployeeService(DataContext context) => _dbContext = context;

    public async Task<IEnumerable<Employee>> GetAllEmployeeAsync()
    {
        return await _dbContext.Employees.ToListAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int? id)
    {
        return await _dbContext.Employees.FindAsync(id);
    }

    public async Task CreateNewEmployeeAsync(Employee? employee)
    {
        if (employee is null) return;

        await _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateEmployeeAsync(Employee? employee)
    {
        if (employee is null) return;

        _dbContext.Employees.Update(employee);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(int? id)
    {
        var emp = await GetEmployeeByIdAsync(id);
        if (emp is not null)
        {
            _dbContext.Employees.Remove(emp);
            await _dbContext.SaveChangesAsync();
        }
    }
}
