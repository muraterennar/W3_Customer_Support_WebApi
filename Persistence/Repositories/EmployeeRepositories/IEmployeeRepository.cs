using Domain.Entities;

namespace Persistence.Repositories.EmployeeRepositories;

public interface IEmployeeRepository
{
    Task<Employee> GetEmployeeByIdAsync(int id);
    Task<Employee> GetEmployeeByUserNameAsync(string username);
    Task<List<Employee>> GetEmployeesAsync();
    Task<Employee> AddEmployeeAsync(Employee employee);
    Task<Employee> UpdateEmployeeAsync(Employee employee);
    Task<Employee> DeleteEmployeeAsync(int id);
}