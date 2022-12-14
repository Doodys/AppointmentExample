using Appointment.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Data.Contexts;

public class AppointmentContext : DbContext
{
	public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options) { }

    public DbSet<Entities.Appointment>? Appointments { get; set; }
}
