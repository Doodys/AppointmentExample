﻿using Appointment.Data.Contexts;
using Appointment.Data.Services.Interfaces;
using Appointment.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Appointment.Data.Entities;
using Appointment.Data.Dtos;

namespace Appointment.Data.Services;

public class AppointmentService : IAppointmentService
{
    private readonly AppointmentContext _appointmnentContext;
    private List<string> _availableHours = new() { "10", "12", "14", "16" };

    public AppointmentService(AppointmentContext appointmnentContext)
    {
        _appointmnentContext = appointmnentContext;
    }

    /// <inheritdoc/>
    public async Task<AppointmentHoursResponseDto> CheckEmployeeAvailability(AppointmentHoursRequestDto request)
    {
        var employeeAppointmnents = await _appointmnentContext.Appointments!
            .Where(x => x.EmployeeId == request.EmployeeId && x.Date == request.Date)
            .ToListAsync();

        if (employeeAppointmnents.Count == 0)
            return new() { Hours = _availableHours };

        foreach (var appointment in employeeAppointmnents)
        {
            _availableHours.Remove(appointment.Hour);
        }

        if (_availableHours.Count == 0)
            throw new AppException($"No available hours for the date {request.Date}");

        return new() { Hours = _availableHours };
    }

    /// <inheritdoc/>
    public async Task RemoveAppointment(Entities.Appointment appointment)
    {
        _appointmnentContext.Appointments!.Remove(appointment);
        await _appointmnentContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task Create(Entities.Appointment appointment)
    {
        await _appointmnentContext.Appointments!.AddAsync(appointment);
        await _appointmnentContext.SaveChangesAsync();
    }
}