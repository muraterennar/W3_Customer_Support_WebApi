namespace Core.Security.Entities;

public class SecurityUser
{
    public int EmployeeId { get; set; }
    public string EmployeeCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public string Username { get; set; }
    public string Email { get; set; }

    public SecurityUser()
    {
        EmployeeCode = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Username = string.Empty;
        Email = string.Empty;
    }

    public SecurityUser(int employeeId, string employeeCode, string firstName, string lastName, string username, string email)
    {
        EmployeeId = employeeId;
        EmployeeCode = employeeCode;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Email = email;
    }
}