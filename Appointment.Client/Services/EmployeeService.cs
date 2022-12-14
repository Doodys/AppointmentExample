using Appointment.Client.Models;

namespace Appointment.Client.Services;

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

    public async Task<Employee> GetById(int id)
    {
        return await _httpService.Get<Employee>($"/Employee/{id}");
    }
}
