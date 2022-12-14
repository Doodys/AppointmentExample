namespace Appointment.Client.Models;

public class Appointment
{
    public DateTime Date { get; set; }
    public string Hour { get; set; }
    public int UserId { get; set; }
    public int EmployeeId { get; set; }
}
