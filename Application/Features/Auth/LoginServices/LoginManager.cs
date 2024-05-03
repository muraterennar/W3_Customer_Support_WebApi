using Application.Features.Auth.Rules;
using Application.Features.UserService;
using Core.Entities;
using Domain.Dtos;
using Domain.Entities;

namespace Application.Features.Auth.LoginServices;

public class LoginManager : ILoginService
{
    private readonly IUserService _userService;
    private readonly AuthRules _authRules;

    public LoginManager(IUserService userService, AuthRules authRules)
    {
        _userService = userService;
        _authRules = authRules;
    }

    public async Task<CommonResponse<LoginResponse>> LoginAsync(LoginDto loginDto)
    {
        await _authRules.IsUserNotExist(loginDto.Username);
        await _authRules.IsPasswordCorrect(loginDto.Username, loginDto.Password);


        Employee getEmployee = await _userService.GetByEmailForUserAsync(loginDto.Username);

        //SecurityUser securityUser = new SecurityUser
        //{
        //    FirstName = getEmployee.EMPLOYEE_NAME,
        //    LastName = getEmployee.EMPLOYEE_SURNAME,
        //    Email = getEmployee.EMPLOYEE_EMAIL,
        //    EmployeeId = getEmployee.Id,
        //    Username = getEmployee.EMPLOYEE_USERNAME
        //};

        //var accessToken = JWTHelper.CreateToken(getEmployee);
        //TODO: Implement JWT Token


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