using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }


    [HttpPost]
    public async Task<Response<GetAttendanceDto>> Post(GetAttendanceDto attendance)
    {
        var newAttendance = await _attendanceService.AddAttendance(attendance);
        return newAttendance;

    }
}