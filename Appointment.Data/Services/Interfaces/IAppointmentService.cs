using Appointment.Data.Dtos;

namespace Appointment.Data.Services.Interfaces;

public interface IAppointmentService
{
    /// <summary>
    /// Check available hours for employee and given date
    /// </summary>
    /// <param name="request"></param>
    /// <returns>List of available hours for employee and given date</returns>
    Task<AppointmentHoursResponseDto> CheckEmployeeAvailability(AppointmentHoursRequestDto request);

    /// <summary>
    /// Remove appointment
    /// </summary>
    /// <param name="appointment"></param>
    Task RemoveAppointment(Entities.Appointment appointment);

    /// <summary>
    /// Create appointment
    /// </summary>
    /// <param name="appointment"></param>
    Task Create(Entities.Appointment appointment);
}
