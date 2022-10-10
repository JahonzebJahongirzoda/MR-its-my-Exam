using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class AddEmployeeDto
{
    public int Id { get; set; }
    public string Phone { get; set; } 
    public string Name { get; set; } 
    public string Surname  { get; set; }
    public string FullInformation  { get; set; }


}