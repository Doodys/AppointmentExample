using Appointment.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Appointment.UnitTests.Mocks;

public static class ContextOptionsMock
{
    public static DbContextOptions<AppointmentContext> DummyAppointmentOptions { get; } = new DbContextOptionsBuilder<AppointmentContext>().Options;
    public static DbContextOptions<EmployeeContext> DummyEmployeeOptions { get; } = new DbContextOptionsBuilder<EmployeeContext>().Options;
    public static DbContextOptions<UserContext> DummyUserOptions { get; } = new DbContextOptionsBuilder<UserContext>().Options;
}
