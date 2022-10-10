using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.AutoMapper;

public class InfrastructureProfile:Profile
{
    public InfrastructureProfile()
    {
        CreateMap<Employee, GetEmployeeDto>();
        CreateMap<Employee, GetEmployeeDto>();
         CreateMap<Attendance, GetAttendanceDto>();
          CreateMap< AddEmployeeDto,Employee>(); 
          
        CreateMap<GetEmployeeDto , Employee >();
       
        CreateMap<GetAttendanceDto, Attendance>();
        CreateMap<Employee, AddEmployeeDto>(); 
       
        
        
        
        
        
    }
}