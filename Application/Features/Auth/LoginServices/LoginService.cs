using Application.Features.EmployeeServices;
using Core.Entities;
using Core.Helpers;
using Core.Security.Entities;
using Core.Security.JWT;
using Domain.Dtos;
using Domain.Entities;

namespace Application.Features.Auth.LoginServices;

public class LoginService : ILoginService
{
    private readonly IEmployeeService _employeeService;

    public LoginService(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task<CommonResponse<LoginResponse>> LoginAsync(LoginDto loginDto)
    {
        Employee getEmployee = await _employeeService.GetEmployeeByUserNameAsync(loginDto.Username);

        if(getEmployee == null)
        {
            return new CommonResponse<LoginResponse>
            {
                Data = new LoginResponse(),
                Message = "Invalid User",
                IsSuccess = false
            };
        }

        var passwordHash = HashingPassword.VerifyPassword(loginDto.Password, getEmployee.EMPLOYEE_PASSWORD);

        SecurityUser securityUser = new SecurityUser
        {
            FirstName = getEmployee.EMPLOYEE_NAME,
            LastName = getEmployee.EMPLOYEE_SURNAME,
            Email = getEmployee.EMPLOYEE_EMAIL,
            EmployeeId = getEmployee.Id,
            Username = getEmployee.EMPLOYEE_USERNAME
        };

        //var accessToken = JWTHelper.CreateToken(getEmployee);
        //TODO: Implement JWT Token


        if(!passwordHash)
        {
            return new CommonResponse<LoginResponse>
            {
                Data = new LoginResponse(),
                Message = "Invalid Password",
                IsSuccess = false
            };
        }

        return new CommonResponse<LoginResponse>
        {
            Data = new LoginResponse
            {
                Id = getEmployee.Id,
                Username = getEmployee.EMPLOYEE_USERNAME,
                FirstName = getEmployee.EMPLOYEE_NAME,
                LastName = getEmployee.EMPLOYEE_SURNAME,
                Email = getEmployee.EMPLOYEE_EMAIL
            },
            Message = "Login Success",
            IsSuccess = true
        };
    }
}