using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AttendanceService : IAttendanceService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public AttendanceService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }



    public async Task<Response<GetAttendanceDto>> AddAttendance(GetAttendanceDto model)
    {
        try
        {
            var group = _mapper.Map<Attendance>(model);
            await _context.Attendance.AddAsync(group);
            await _context.SaveChangesAsync();
            model.Id = group.Id;
            return new Response<GetAttendanceDto>(model);
        }
        catch (System.Exception ex)
        {
            return new Response<GetAttendanceDto>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    // public async void GetAveraga(int employeeid)
    // {
    //     
    //     var findAsync = await _context.Attendance.FindAsync(employeeid);
    //     var result = findAsync.ComeAt(s => s.employeeid)
    //         .Select(g => new {employeeid=g.Key, Avg=g.Average(s => s.GPA)});
    // }


}
