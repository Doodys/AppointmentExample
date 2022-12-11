using DoctorAppointment.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Data.Contexts;

public class AppointmentContext : DbContext
{
	public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options) { }

    public DbSet<Appointment>? Appointments { get; set; }
}
