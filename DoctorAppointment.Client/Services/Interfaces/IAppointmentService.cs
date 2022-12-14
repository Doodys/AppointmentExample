using DoctorAppointment.Client.Models;

namespace DoctorAppointment.Client.Services.Interfaces;

public interface IAppointmentService
{
    Task<AppointmentHoursResponse> GetAvailableHours(AppointmentHoursRequest request);
    Task Create(Appointment appointment);
    Task Remove(Appointment appointment);
}
