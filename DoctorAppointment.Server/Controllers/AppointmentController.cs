using DoctorAppointment.Data.Dtos;
using DoctorAppointment.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointment.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly ILogger<AppointmentController> _logger;
    private readonly IAppointmentService _appointmentService;
    private readonly EmployeeContext _employeeContext;

    public AppointmentController(ILogger<AppointmentController> logger, IAppointmentService appointmentService, EmployeeContext employeeContext)
    {
        _appointmentService = appointmentService;
        _logger = logger;
        _employeeContext = employeeContext;
    }

    [HttpPost]
    [Route("employeeAvailability")]
    public async Task<ActionResult<AppointmentHoursResponseDto>> CheckAvailableHours(AppointmentHoursRequestDto request)
    {
        var employee = await _employeeContext.Employees.Where(x => x.Id == request.EmployeeId).FirstOrDefaultAsync();

        if (employee == null)
            throw new AppException("Employee does not exist!");

        var hours = await _appointmentService.CheckEmployeeAvailability(request);

        return Ok(hours);
    }

    [HttpPut]
    [Route("createAppointment")]
    public async Task<IActionResult> Create(Appointment appointment)
    {
        await _appointmentService.Create(appointment);

        return Ok();
    }

    [HttpPost]
    [Route("removeAppointment")]
    public async Task<IActionResult> Remove(Appointment appointment)
    {
        await _appointmentService.RemoveAppointment(appointment);

        return Ok();
    }
}
