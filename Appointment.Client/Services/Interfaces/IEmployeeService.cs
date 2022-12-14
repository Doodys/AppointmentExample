using Appointment.Client.Models;

namespace Appointment.Client.Services.Interfaces;

public interface IEmployeeService
{
    Task<IList<Employee>> GetAll();
    Task<Employee> GetById(int id);
}
