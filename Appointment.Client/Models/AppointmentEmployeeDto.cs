namespace Appointment.Client.Models;

public class AppointmentEmployeeDto
{
    public int Id { get; set; } = 0;
    public DateTime Date { get; set; }
    public string Hour { get; set; }
    public int UserId { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = new();
}

