using Application.Features.EmployeeServices;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetEmployees()
    {
        var employees = await _employeeService.GetEmployeesAsync();
        return Ok(employees);
    }

    [HttpGet("getbyid/{id}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);
        return Ok(employee);
    }

    [HttpGet("getbyusername/{username}")]
    public async Task<IActionResult> GetEmployeeByUserName(string username)
    {
        var employee = await _employeeService.GetEmployeeByUserNameAsync(username);
        return Ok(employee);
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddEmployee(Employee employeeDto)
    {
        var employee = await _employeeService.AddEmployeeAsync(employeeDto);
        return Ok(employee);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateEmployee(Employee employeeDto)
    {
        var employee = await _employeeService.UpdateEmployeeAsync(employeeDto);
        return Ok(employee);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var employee = await _employeeService.DeleteEmployeeAsync(id);
        return Ok(employee);
    }
}
