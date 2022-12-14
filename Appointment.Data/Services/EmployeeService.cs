using AutoMapper;
using Appointment.Data.Contexts;
using Appointment.Data.Entities;
using Appointment.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Data.Services;

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
