using Domain.Entities;

namespace Application.Features.UserService;

public interface IUserService
{
    Task<List<Employee>> GetAllUsersAsync();
    Task<Employee> GetByIdForUserAsync(int id);
    Task<Employee> GetByFirstNameForUserAsync(string firstname);
    Task<Employee> GetByLastNameForUserAsync(string lastname);
    Task<Employee> GetByEmailForUserAsync(string email);
    Task<Employee> GetByPhoneNumberForUserAsync(string phonenumber);
    Task<Employee> AddUserAsync(Employee user);
    Task<Employee> UpdateUserAsync(Employee user);
    Task<Employee> DeleteUserAsync(int id);
}