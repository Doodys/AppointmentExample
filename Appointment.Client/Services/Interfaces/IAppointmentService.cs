using Appointment.Client.Models;

namespace Appointment.Client.Services.Interfaces;

public interface IAppointmentService
{
    Task<AppointmentHoursResponse> GetAvailableHours(AppointmentHoursRequest request);
    Task Create(Models.Appointment appointment);
    Task Remove(Models.Appointment appointment);
}
