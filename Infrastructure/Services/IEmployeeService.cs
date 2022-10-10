using Domain.Dtos;

namespace Infrastructure.Services;

public interface IEmployeeService
{
    Task<Response<List<GetEmployeeDto>>> GetEmployees();
    Task<Response<List<GetEmployeeWithAttendanceDto>>> GetEmployeeWithAttendance(int id);
    Task<Response<AddEmployeeDto>> AddEmployee(AddEmployeeDto model);
    Task<Response<GetEmployeeDto>> GetEmployeeByName(string name,string phone);
    Task<Response<GetEmployeeDto>> GetEmployeeByPhone(string phone);
    Task<Response<AddEmployeeDto>> UpdateEmployee(AddEmployeeDto attendanceDto);
    Task<Response<string>> DeleteEmployee(int id);

}