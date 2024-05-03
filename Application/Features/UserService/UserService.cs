using Domain.Entities;
using Persistence.Repositories.UserDetailRepository;
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

    string userDetailCommonQuery = "SELECT [E].[EMPLOYEE_ID], [E].[COMPANY_ID], [E].[EMPLOYEE_NO],[E].[EMPLOYEE_EMAIL], [E].[EMPLOYEE_NAME], [E].[EMPLOYEE_SURNAME], [E].[EMPLOYEE_USERNAME], [EP].[POSITION_NAME], [UOC].[Id] AS [USER_OPERATION_CLAIM_ID], [OC].[Id] AS [OPERATION_CLAIM_ID], [OC].[Name] AS [OPERATION_NAME], [UG].[USER_GROUP_ID] AS [W3_OPERATION_ID], [UG].[USER_GROUP_NAME] AS [W3_OPERATION_NAME] FROM [CatalystQa].[EMPLOYEES] AS [E] LEFT JOIN [CatalystQa].[EMPLOYEE_POSITIONS] AS [EP] ON [E].[EMPLOYEE_ID] = [EP].[EMPLOYEE_ID] LEFT JOIN [CatalystQa].[USER_GROUP_EMPLOYEE] AS [UGE] ON [EP].[EMPLOYEE_ID] = [UGE].[EMPLOYEE_ID] LEFT JOIN [CatalystQa].[USER_GROUP] AS [UG] ON [UGE].[USER_GROUP_ID] = [UG].[USER_GROUP_ID] LEFT JOIN [CatalystQa].[USER_OPERATION_CLAIMS] AS [UOC] ON [E].[EMPLOYEE_ID] = [UOC].[UserId] LEFT JOIN [CatalystQa].[OPERATION_CLAIMS] AS [OC] ON [UOC].[OperationClaimId] = [OC].[Id]";


    private readonly IUserRepository _userRepository;
    private readonly IUserDetailRepository _userDetailRepository;

    public UserService(IUserRepository userRepository, IUserDetailRepository userDetailRepository)
    {
        _userRepository = userRepository;
        _userDetailRepository = userDetailRepository;
    }

    public async Task<List<Employee>> GetAllUsersAsync()
    {
        List<Employee> employees = await _userRepository.GetAll(commonQuery);
        return employees;
    }

    public async Task<List<UserDetail>> GetAllUserDetailAsync()
    {
        List<UserDetail> userDetails = await _userDetailRepository.GetAll(userDetailCommonQuery);
        return userDetails;
    }

    public async Task<List<UserDetail>> GetUserIdForUserDetailListAsync(int userId)
    {
        string query = $"{userDetailCommonQuery} WHERE [E].[EMPLOYEE_ID] = '{userId}'";
        List<UserDetail> userDetails = await _userDetailRepository.GetAll(query);
        return userDetails;
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

    public async Task<Employee> GetByUsernameForUserAsync(string username)
    {
        string query = $"{commonQuery} WHERE [EMPLOYEE_USERNAME] = '{username}'";

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