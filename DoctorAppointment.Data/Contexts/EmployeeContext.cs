using DoctorAppointment.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Data.Contexts;

public class EmployeeContext : DbContext
{
    public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

    public DbSet<Employee>? Employees { get; set; }
}
