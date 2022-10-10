using Domain.Dtos;

namespace Infrastructure.Services;

public interface IAttendanceService
{
    Task<Response<GetAttendanceDto>> AddAttendance(GetAttendanceDto model);
}