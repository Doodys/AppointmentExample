using AutoMapper;
using DoctorAppointment.Data.Contexts;
using DoctorAppointment.Data.Entities;
using DoctorAppointment.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Data.Services;

#pragma warning disable CS8603

public class EmployeeService : IEmployeeService
{
    private readonly EmployeeContext _employeeContext;
    private readonly IMapper _mapper;

    public EmployeeService(EmployeeContext employeeContext)
    {
        _employeeContext = employeeContext;
    }

    /// <inheritdoc/>
    public async Task<List<Employee>> GetAll()
    {
        return await _employeeContext.Employees!
                .ToListAsync();
    }
}
