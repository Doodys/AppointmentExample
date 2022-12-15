using Appointment.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Data.Contexts;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options) { }

    public virtual DbSet<User>? Users { get; set; }
}
