namespace Appointment.Data.Entities;

public class Appointment
{
    public int Id { get; set; } = 0;
    public DateTime Date { get; set; }
    public string Hour { get; set; }
    public int UserId { get; set; }
    public int EmployeeId { get; set; }
}
