using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class EmployeeService : IEmployeeService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public EmployeeService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task<Response<List<GetEmployeeDto>>> GetEmployees()
    {
        var locations = _mapper.Map<List<GetEmployeeDto>>(_context.Employees.ToList());
        return Task.FromResult(new Response<List<GetEmployeeDto>>(locations));
    }
    
  
    public async Task<Response<List<GetEmployeeWithAttendanceDto>>> GetEmployeeWithAttendance(int id)
    {
        var findAsync = await _context.Employees.FindAsync(id);
        var employees = await (
            from em in _context.Employees
            where  em.Id == id
            select new GetEmployeeWithAttendanceDto()
            {
                Phone = em.Phone,
                Id = em.Id,
                Name = em.Name,
                Surname = em.Surname,  
                FullInformation = em.FullInformation,
                
                Attendance = (
                    from gr in _context.Attendance
                    where gr.EmployeeId == em.Id
                    select _mapper.Map<GetAttendanceDto>(gr)
                ).ToList()
            }
        ).ToListAsync();

        return new Response<List<GetEmployeeWithAttendanceDto>>(employees);
    }


    
    
    
    
    
    

    public async Task<Response<AddEmployeeDto>> AddEmployee(AddEmployeeDto model)
    {
        try
        {
            var attendance = _mapper.Map<Employee>(model);
            await _context.Employees.AddAsync(attendance);
            await _context.SaveChangesAsync();
            model.Id = attendance.Id;
            return new Response<AddEmployeeDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<AddEmployeeDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }







    public async Task<Response<GetEmployeeDto>> GetEmployeeByName(string name, string phone)
    {
        var find = _mapper.Map<GetEmployeeDto>( from employee in _context.Employees where employee.Name.Contains(name) || employee.Phone.Contains(phone) select employee);
        if (find == null){ return new Response<GetEmployeeDto>(HttpStatusCode.NotFound, "");}
        return new Response<GetEmployeeDto>(find);
    }
    
    
    
    
    
    
    
    public async Task<Response<GetEmployeeDto>> GetEmployeeByPhone(string phone)
    {
        var find = _mapper.Map<GetEmployeeDto>(await _context.Employees.FindAsync(phone));
        if (find == null) return new Response<GetEmployeeDto>(HttpStatusCode.NotFound, "");
        return new Response<GetEmployeeDto>(find);
    }

    
 
    
    

    public async Task<Response<AddEmployeeDto>> UpdateEmployee(AddEmployeeDto attendanceDto)
    {
        try
        {
            var finds = await _context.Employees.FindAsync(attendanceDto.Id);
            if (finds == null) return new Response<AddEmployeeDto>(System.Net.HttpStatusCode.NotFound, "");
            
            finds.Phone = attendanceDto.Phone;
            finds.Id = attendanceDto.Id;
            finds.Name = attendanceDto.Name; 
            finds.Surname = attendanceDto.Surname;
            finds.FullInformation = attendanceDto.FullInformation; 
   
            await _context.SaveChangesAsync();
            return new Response<AddEmployeeDto>(attendanceDto);
        }
        catch (System.Exception ex)
        {
            return new Response<AddEmployeeDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    
    
    
    
    
    
    public async Task<Response<string>> DeleteEmployee(int id)
    {
        try
        {
            var find = await _context.Employees.FindAsync(id);
            if (find == null) return new Response<string>(System.Net.HttpStatusCode.NotFound, "");

            _context.Employees.Remove(find);
            await _context.SaveChangesAsync();
            return new Response<string>("removed successfully");
        }
        catch (System.Exception ex)
        {
            return new Response<string>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}