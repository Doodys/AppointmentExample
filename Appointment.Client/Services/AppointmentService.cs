using Appointment.Client.Models;

namespace Appointment.Client.Services;

public class AppointmentService : IAppointmentService
{
    private IHttpService _httpService;

    public AppointmentService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<AppointmentHoursResponse> GetAvailableHours(AppointmentHoursRequest request)
    {
        return await _httpService.Post<AppointmentHoursResponse>("/Appointment/employeeAvailability", request);
    }

    public async Task Create(Models.Appointment appointment)
    {
        await _httpService.Put("/Appointment/createAppointment", appointment);
    }

    public async Task Remove(Models.Appointment appointment)
    {
        await _httpService.Post("/Appointment/removeAppointment", appointment);
    }
}
