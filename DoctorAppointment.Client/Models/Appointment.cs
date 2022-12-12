namespace DoctorAppointment.Client.Models;

public class Appointment
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
    public int EmployeeId { get; set; }
    public string Text { get; set; }
}
