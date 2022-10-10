using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Employee
{

    public int Id { get; set; }
    [Required,MaxLength(200)]
    public string? Phone { get; set; } 
    [Required,MaxLength(200)]
    public string? Name { get; set; } 
    [Required,MaxLength(200)]
    public string? Surname  { get; set; }
    [Required,MaxLength(200)]
    public string? FullInformation  { get; set; }
   
    public virtual List<Attendance>? Attendance { get; set; }
}