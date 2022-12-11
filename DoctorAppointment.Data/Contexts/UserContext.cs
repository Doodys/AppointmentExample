using DoctorAppointment.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Data.Contexts;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options) { }

    public DbSet<User>? Users { get; set; }
}
