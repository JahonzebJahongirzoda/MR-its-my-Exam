namespace Domain.Dtos;

public class GetAttendanceDto
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public TimeSpan ComeAt { get; set; }
}