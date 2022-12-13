using DoctorAppointment.Client.Models;

namespace DoctorAppointment.Client.Services.Interfaces;

public interface IEmployeeService
{
    Task<IList<Employee>> GetAll();
    Task<Employee> GetById(int id);
}
