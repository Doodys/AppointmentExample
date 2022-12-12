using DoctorAppointment.Client.Models;

namespace DoctorAppointment.Client.Services;

public class EmployeeService : IEmployeeService
{
    private IHttpService _httpService;

    public EmployeeService(
        IHttpService httpService)
    {
        _httpService = httpService;
    }
    public async Task<IList<Employee>> GetAll()
    {
        return await _httpService.Get<IList<Employee>>("/Employee");
    }
}
