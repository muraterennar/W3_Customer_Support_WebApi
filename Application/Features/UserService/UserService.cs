using Domain.Entities;
using Persistence.Repositories.UserRepositories;

namespace Application.Features.UserService;

public class UserService : IUserService
{
    string commonQuery = "SELECT [EMPLOYEE_STATUS],[EMPLOYEE_ID]," +
        "[EMPAPP_ID],[MEMBER_CODE],[EMPLOYEE_USERNAME],[EMPLOYEE_PASSWORD],[EMPLOYEE_NO]," +
        "[EMPLOYEE_NAME],[EMPLOYEE_SURNAME],[TASK],[EMPLOYEE_EMAIL],[__IMCAT_ID],[__IM],[__IMCAT2_ID]," +
        "[__IM2],[DIRECT_TELCODE],[DIRECT_TEL],[EXTENSION],[MOBILCODE],[MOBILTEL],[CORBUS_TEL],[PHOTO]," +
        "[IS_AGENDA_OPEN],[PERIOD_ID],[COMPANY_ID],[IS_IP_CONTROL],[IP_ADDRESS],[COMPUTER_NAME],[GROUP_STARTDATE]," +
        "[DYNAMIC_HIERARCHY],[DYNAMIC_HIERARCHY_ADD],[HIERARCHY],[OZEL_KOD],[RECORD_DATE],[RECORD_EMP],[RECORD_IP]," +
        "[UPDATE_DATE],[UPDATE_EMP],[UPDATE_IP],[OZEL_KOD2],[KIDEM_DATE],[IZIN_DATE],[IN_COMPANY_REASON_ID],[IS_CRITICAL]," +
        "[PHOTO_SERVER_ID],[EXPIRY_DATE],[EMPLOYEE_STAGE],[BIOGRAPHY],[WET_SIGNATURE],[PER_ASSIGN_ID],[IS_ACC_INFO],[IZIN_DAYS]," +
        "[OLD_SGK_DAYS],[EXT_OFFTIME_MINUTES],[EXT_OFFTIME_DATE],[EMPLOYEE_KEP_ADRESS],[WORKTIPS_OPEN],[EINS_POINT],[BRUC_POINT]," +
        "[TEL_TYPE],[IS_VACCINE],[IS_COVID] FROM [CatalystQa].[EMPLOYEES]";


    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<Employee>> GetAllUsersAsync()
    {
        List<Employee> employees = await _userRepository.GetAll(commonQuery);
        return employees;
    }

    public async Task<Employee> GetByIdForUserAsync(int id)
    {
        string query = $"{commonQuery} WHERE [EMPLOYEE_ID] = '{id}'";

        Employee employee = await _userRepository.GetByAny(query);
        return employee;
    }

    public async Task<Employee> GetByFirstNameForUserAsync(string firstname)
    {
        string query = $"{commonQuery} WHERE [EMPLOYEE_NAME] = '{firstname}'";

        Employee employee = await _userRepository.GetByAny(query);
        return employee;
    }

    public async Task<Employee> GetByLastNameForUserAsync(string lastname)
    {
        string query = $"{commonQuery} WHERE [EMPLOYEE_SURNAME] = '{lastname}'";

        Employee employee = await _userRepository.GetByAny(query);
        return employee;
    }

    public async Task<Employee> GetByEmailForUserAsync(string email)
    {
        string query = $"{commonQuery} WHERE [EMPLOYEE_EMAIL] = '{email}'";

        Employee employee = await _userRepository.GetByAny(query);
        return employee;
    }

    public async Task<Employee> GetByPhoneNumberForUserAsync(string phonenumber)
    {
        string query = $"{commonQuery} WHERE [MOBILTEL] = '{phonenumber}'";

        Employee employee = await _userRepository.GetByAny(query);
        return employee;
    }

    public async Task<Employee> AddUserAsync(Employee user)
    {
        throw new NotImplementedException();
    }

    public async Task<Employee> UpdateUserAsync(Employee user)
    {
        throw new NotImplementedException();
    }

    public async Task<Employee> DeleteUserAsync(int id)
    {
        throw new NotImplementedException();
    }
}