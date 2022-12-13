using AutoMapper;
using DoctorAppointment.Data.Contexts;
using DoctorAppointment.Data.Entities;
using DoctorAppointment.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Data.Services;

public class EmployeeService : IEmployeeService
{
    private readonly EmployeeContext _employeeContext;

    public EmployeeService(EmployeeContext employeeContext)
    {
        _employeeContext = employeeContext;
    }

    /// <inheritdoc/>
    public async Task<List<Employee>> GetAll()
    {
        return await _employeeContext.Employees!
                .OrderBy(x => x.Surname)
                .ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<Employee> GetById(int id)
    {
        return await _employeeContext.Employees!
                .FirstOrDefaultAsync(x => x.Id == id);
    }
}
