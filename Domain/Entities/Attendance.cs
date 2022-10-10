using System.ComponentModel.DataAnnotations;
using Domain.Entities;


public class Attendance
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }
    public TimeSpan ComeAt { get; set; }
}
