using Domain.Entities;

namespace Application.Features.UserService;

public interface IUserService
{
    Task<List<Employee>> GetAllUsersAsync();
    Task<List<UserDetail>> GetAllUserDetailAsync();
    Task<List<UserDetail>> GetUserIdForUserDetailListAsync(int userId);
    Task<Employee> GetByIdForUserAsync(int id);
    Task<Employee> GetByFirstNameForUserAsync(string firstname);
    Task<Employee> GetByLastNameForUserAsync(string lastname);
    Task<Employee> GetByEmailForUserAsync(string email);
    Task<Employee> GetByUsernameForUserAsync(string username);
    Task<Employee> GetByPhoneNumberForUserAsync(string phonenumber);
    Task<Employee> AddUserAsync(Employee user);
    Task<Employee> UpdateUserAsync(Employee user);
    Task<Employee> DeleteUserAsync(int id);
}