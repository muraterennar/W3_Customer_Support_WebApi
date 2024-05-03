using Core.Exceptions;
using Core.Helpers;
using Core.Rules;
using Domain.Entities;
using Persistence.Repositories.UserRepositories;

namespace Application.Features.Auth.Rules;

public class AuthRules : BaseBusinessRules
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

    public AuthRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task IsUserExist(string username)
    {
        string query = $"{commonQuery} WHERE [EMPLOYEE_USERNAME] = '{username}'";
        Employee user = await _userRepository.GetByAny(query);

        if(user != null)
            throw new AuthException("User already exist");
    }

    public async Task IsUserExist(int Id)
    {
        string query = $"{commonQuery} WHERE [EMPLOYEE_ID] = '{Id}'";
        Employee user = await _userRepository.GetByAny(query);

        if(user != null)
            throw new AuthException("User already exist");
    }

    public async Task IsUserNotExist(string username)
    {
        string query = $"{commonQuery} WHERE [EMPLOYEE_USERNAME] = '{username}'";
        Employee user = await _userRepository.GetByAny(query);

        if(user == null)
            throw new AuthException("User not found");
    }

    public async Task IsUserNotExist(int Id)
    {
        string query = $"{commonQuery} WHERE [EMPLOYEE_USERNAME] = '{Id}'";
        Employee user = await _userRepository.GetByAny(query);

        if(user == null)
            throw new AuthException("User not found");
    }

    public async Task IsPasswordCorrect(string username, string password)
    {
        string query = $"{commonQuery} WHERE [EMPLOYEE_USERNAME] = '{username}'";
        Employee user = await _userRepository.GetByAny(query);

        bool IsSuceess = HashingPassword.VerifyPassword(password, user.EMPLOYEE_PASSWORD);

        if(!IsSuceess)
            throw new AuthException("Password or username is incorrect");
    }

    public async Task IsPasswordNotCorrect(string username, string password)
    {
        string query = $"{commonQuery} WHERE [EMPLOYEE_USERNAME] = '{username}'";
        Employee user = await _userRepository.GetByAny(query);

        bool IsSuceess = HashingPassword.VerifyPassword(password, user.EMPLOYEE_PASSWORD);

        if(IsSuceess)
            throw new AuthException("Password or username is incorrect");
    }
}
