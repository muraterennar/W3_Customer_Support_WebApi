using Domain.Entities;
using Persistence.Repositories.EmployeeRepositories;

namespace Application.Features.EmployeeServices;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<List<Employee>> GetEmployeesAsync()
    {
        return await _employeeRepository.GetEmployeesAsync();
    }

    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
        return await _employeeRepository.GetEmployeeByIdAsync(id);
    }

    public async Task<Employee> GetEmployeeByUserNameAsync(string username)
    {
        return await _employeeRepository.GetEmployeeByUserNameAsync(username);
    }

    public async Task<Employee> UpdateEmployeeAsync(Employee employee)
    {
        return await _employeeRepository.UpdateEmployeeAsync(employee);
    }

    public async Task<Employee> AddEmployeeAsync(Employee employee)
    {
        return await _employeeRepository.AddEmployeeAsync(employee);
    }

    public async Task<Employee> DeleteEmployeeAsync(int id)
    {
        return await _employeeRepository.DeleteEmployeeAsync(id);
    }
}