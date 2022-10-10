namespace Domain.Dtos;

public class GetEmployeeWithAttendanceDto
{
    public int Id { get; set; }
    public string Phone { get; set; } 
    public string Name { get; set; } 
    public string Surname  { get; set; }
    public string FullInformation  { get; set; }
    public List<GetAttendanceDto> Attendance { get; set; }
}