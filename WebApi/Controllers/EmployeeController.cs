using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<Response<List<GetEmployeeDto>>> Get()
    {
        var employees = await _employeeService.GetEmployees();
        return employees;
    }
    
    
    
    
    
    
    [HttpGet("GetEmployeeWithAttendances")]
    public async  Task<Response<List<GetEmployeeWithAttendanceDto>>> GetEmployeeWithAttendances(int id)
    {
        var employees = await _employeeService.GetEmployeeWithAttendance(id);
        return employees;
    }
    
    
    
    [HttpGet("Get")]
    public async Task<Response<GetEmployeeDto>> Get(string name,string phone)
    {
        var employee = await _employeeService.GetEmployeeByName(name,phone);
        return employee;
    }
    
    
    [HttpGet("GetByPhone")]
    public async Task<Response<GetEmployeeDto>> GetByPhone(string phone)
    {
        var employee = await _employeeService.GetEmployeeByPhone(phone);
        return employee;
    }
    
    
    
    
    
    [HttpPost]
    public async Task<Response<AddEmployeeDto>> Post(AddEmployeeDto employee)
    {
        var newEmployee = await _employeeService.AddEmployee(employee);
        return newEmployee;
    }
    
    [HttpPut]
    public async Task<Response<AddEmployeeDto>> Put(AddEmployeeDto employee)
    {
        var updatedEmployee = await _employeeService.UpdateEmployee(employee);
        return updatedEmployee;
    }
    
    [HttpDelete]
    public async Task<Response<string>> Delete(int id)
    {
        var employee = await _employeeService.DeleteEmployee(id);
        return employee;
    }

}