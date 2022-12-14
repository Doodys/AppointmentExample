using Appointment.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger;
    private readonly IEmployeeService _employeeService;

    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
    {
        _logger = logger;
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Employee>>> GetEmployees()
    {
        return Ok(await _employeeService.GetAll());
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Employee>> GetById(int id)
    {
        return Ok(await _employeeService.GetById(id));
    }
}