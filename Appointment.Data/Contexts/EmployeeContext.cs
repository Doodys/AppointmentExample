using Appointment.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Data.Contexts;

public class EmployeeContext : DbContext
{
    public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

    public virtual DbSet<Employee>? Employees { get; set; }
}
