using Microsoft.EntityFrameworkCore;

namespace Appointment.Data.Contexts;

public class AppointmentContext : DbContext
{
	public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options) { }

    public virtual DbSet<Entities.Appointment>? Appointments { get; set; }
}
