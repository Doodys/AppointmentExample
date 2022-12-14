using DoctorAppointment.Client.Models;

namespace DoctorAppointment.Client.Services;

public class AppointmentService : IAppointmentService
{
    private IHttpService _httpService;

    public AppointmentService(IHttpService httpService)
    {
        _httpService = httpService;
    }

    public async Task<AppointmentHoursResponse> GetAvailableHours(AppointmentHoursRequest request)
    {
        return await _httpService.Post<AppointmentHoursResponse>($"/employeeAvailability", request);
    }

    public async Task Create(Appointment appointment)
    {
        await _httpService.Put("/createAppointment", appointment);
    }

    public async Task Remove(Appointment appointment)
    {
        await _httpService.Post("/removeAppointment", appointment);
    }
}
