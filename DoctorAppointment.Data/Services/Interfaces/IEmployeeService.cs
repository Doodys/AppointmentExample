using DoctorAppointment.Data.Entities;

namespace DoctorAppointment.Data.Services.Interfaces;

public interface IEmployeeService
{
    /// <summary>
    /// Get all users
    /// </summary>
    /// <returns></returns>
    Task<List<Employee>> GetAll();

    Task<Employee> GetById(int id);
}
