using Domain.Entities;
using System.Data.SqlClient;
using System.Data;
using Persistence.Repositories.RepositoryMaps;
using Microsoft.Extensions.Configuration;

namespace Persistence.Repositories.EmployeeRepositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IRepositoryMap _mapModel;
    private readonly IConfiguration _conguration;

    public EmployeeRepository(IRepositoryMap mapModel, IConfiguration conguration)
    {
        _mapModel = mapModel;
        _conguration = conguration;
    }

    public async Task<List<Employee>> GetEmployeesAsync()
    {
        List<Employee> employees = new List<Employee>();

        using(SqlConnection connection = new SqlConnection(_conguration.GetConnectionString("DefaultConnection")))
        {
            string query = "SELECT [EMPLOYEE_STATUS],[EMPLOYEE_ID],[EMPAPP_ID],[MEMBER_CODE],[EMPLOYEE_USERNAME],[EMPLOYEE_PASSWORD],[EMPLOYEE_NO],[EMPLOYEE_NAME],[EMPLOYEE_SURNAME],[TASK],[EMPLOYEE_EMAIL],[__IMCAT_ID],[__IM],[__IMCAT2_ID],[__IM2],[DIRECT_TELCODE],[DIRECT_TEL],[EXTENSION],[MOBILCODE],[MOBILTEL],[CORBUS_TEL],[PHOTO],[IS_AGENDA_OPEN],[PERIOD_ID],[COMPANY_ID],[IS_IP_CONTROL],[IP_ADDRESS],[COMPUTER_NAME],[GROUP_STARTDATE],[DYNAMIC_HIERARCHY],[DYNAMIC_HIERARCHY_ADD],[HIERARCHY],[OZEL_KOD],[RECORD_DATE],[RECORD_EMP],[RECORD_IP],[UPDATE_DATE],[UPDATE_EMP],[UPDATE_IP],[OZEL_KOD2],[KIDEM_DATE],[IZIN_DATE],[IN_COMPANY_REASON_ID],[IS_CRITICAL],[PHOTO_SERVER_ID],[EXPIRY_DATE],[EMPLOYEE_STAGE],[BIOGRAPHY],[WET_SIGNATURE],[PER_ASSIGN_ID],[IS_ACC_INFO],[IZIN_DAYS],[OLD_SGK_DAYS],[EXT_OFFTIME_MINUTES],[EXT_OFFTIME_DATE],[EMPLOYEE_KEP_ADRESS],[WORKTIPS_OPEN],[EINS_POINT],[BRUC_POINT],[TEL_TYPE],[IS_VACCINE],[IS_COVID] FROM [CatalystQa].[EMPLOYEES]";

            using(SqlCommand command = new SqlCommand(query, connection))
            {
                if(command.Connection.State == ConnectionState.Closed)
                    await connection.OpenAsync();


                using(SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        employees.Add(_mapModel.MapEmployeeFromDataReader(reader));
                    }
                }

                if(command.Connection.State == ConnectionState.Open)
                    await connection.CloseAsync();
            }
        }

        return employees;
    }

    public async Task<Employee> GetEmployeeByUserNameAsync(string username)
    {
        Employee employee = new Employee();

        using(SqlConnection connection = new SqlConnection(_conguration.GetConnectionString("DefaultConnection")))
        {
            string query = "SELECT * FROM [CatalystQa].[EMPLOYEES] WHERE EMPLOYEE_USERNAME = @EMPLOYEE_USERNAME";

            using(SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EMPLOYEE_USERNAME", username);

                if(command.Connection.State == ConnectionState.Closed)
                    await connection.OpenAsync(); // Asenkron olarak açıyoruz.

                using(SqlDataReader reader = await command.ExecuteReaderAsync()) // Asenkron olarak okuyoruz.
                {
                    while(await reader.ReadAsync()) // Asenkron olarak okuyoruz.
                    {
                        employee = _mapModel.MapEmployeeFromDataReader(reader);
                    }
                }

                if(command.Connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return employee;
        }
    }

    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
        Employee employee = new Employee();

        using(SqlConnection connection = new SqlConnection(_conguration.GetConnectionString("DefaultConnection")))
        {
            string query = "SELECT * FROM [CatalystQa].[EMPLOYEES] WHERE EMPLOYEE_ID = @EMPLOYEE_ID";

            using(SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EMPLOYEE_ID", id);

                if(command.Connection.State == ConnectionState.Closed)
                    await connection.OpenAsync(); // Asenkron olarak açıyoruz.

                using(SqlDataReader reader = await command.ExecuteReaderAsync()) // Asenkron olarak okuyoruz.
                {
                    while(await reader.ReadAsync()) // Asenkron olarak okuyoruz.
                    {
                        employee = _mapModel.MapEmployeeFromDataReader(reader);
                    }
                }

                if(command.Connection.State == ConnectionState.Open)
                    connection.Close();
            }

            return employee;
        }
    }

    public Task<Employee> AddEmployeeAsync(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task<Employee> DeleteEmployeeAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Employee> UpdateEmployeeAsync(Employee employee)
    {
        throw new NotImplementedException();
    }
}