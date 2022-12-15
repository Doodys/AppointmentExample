using Appointment.Data.Contexts;
using Appointment.Data.Dtos;
using Appointment.Data.Services;
using Appointment.UnitTests.Mocks;
using EntityFrameworkCoreMock;
using FluentAssertions;
using Moq;
using Xunit;

namespace Appointment.UnitTests.Services;

// TO-DO-TEST na ten wzór możecie zrobić sobie EmployeeService oraz UserService. Mock contextów oraz samego w sobie
// serwisu macie przedstawione w konstruktorze poniżej. Polecam wczytać się w https://github.com/cup-of-tea-dot-be/entity-framework-core-mock
// którego tutaj użyłem, świetna biblioteka

public class AppointmentServiceTest
{
    private readonly List<string> _availableHours;
    private readonly List<string> _takenHours;
    private readonly int _employeeId;
    private readonly AppointmentService _appointmentService;
    private readonly DbContextMock<AppointmentContext> _appointmentContextMock;
    private readonly DbContextMock<EmployeeContext> _employeeContextMock;
    private readonly DbSetMock<Data.Entities.Appointment> _appointmentsDbSetMock;
    private readonly DbSetMock<Data.Entities.Employee> _employeesDbSetMock;

    public AppointmentServiceTest()
    {
        _takenHours = new() { "10", "12" };
        _employeeId = 1;

        var appointmentEntities = new[]
           {
                new Data.Entities.Appointment {
                    Id = 1,
                    Date = DateTime.Today,
                    Hour = _takenHours[0],
                    UserId = 1,
                    EmployeeId = _employeeId
                },
                new Data.Entities.Appointment {
                   Id = 2,
                   Date = DateTime.Today,
                   Hour = _takenHours[1],
                   UserId = 1,
                   EmployeeId = _employeeId
               }
            };

        _appointmentContextMock = new DbContextMock<AppointmentContext>(ContextOptionsMock.DummyAppointmentOptions);
        _appointmentsDbSetMock = _appointmentContextMock.CreateDbSetMock(x => x.Appointments, appointmentEntities);

        var employeeEntities = new[]
           {
                new Data.Entities.Employee {
                    Id = _employeeId,
                    Name = "Test",
                    Surname = "Testovitch",
                    Specialization = "QA"
                }
            };

        _employeeContextMock = new DbContextMock<EmployeeContext>(ContextOptionsMock.DummyEmployeeOptions);
        _employeesDbSetMock = _employeeContextMock.CreateDbSetMock(x => x.Employees, employeeEntities);

        _appointmentService = new AppointmentService(_appointmentContextMock.Object, _employeeContextMock.Object);

        _availableHours = new() { "10", "12", "14", "16" };
    }

    [Fact]
    public async Task CheckEmployeeAvailability_ShouldReturnHours_WhenRequestProvided()
    {
        // arrange
        var appointmentHoursRequestDto = new AppointmentHoursRequestDto()
        {
            EmployeeId = _employeeId,
            Date = DateTime.Today
        };

        // act
        var result = await _appointmentService.CheckEmployeeAvailability(appointmentHoursRequestDto);

        // assert
        result.Hours.Should().BeEquivalentTo(_availableHours.Except(_takenHours).ToList());
    }

    [Fact]
    public async Task RemoveAppointment_ShouldRemoveItemFromCollection_WhenAppointmentProvided()
    {
        // arrange
        var appointment = new Data.Entities.Appointment
        {
            Id = 1,
            Date = DateTime.Today,
            Hour = _takenHours[0],
            UserId = 1,
            EmployeeId = _employeeId
        };

        // act
        await _appointmentService.RemoveAppointment(appointment);

        // assert
        _appointmentsDbSetMock.Verify(x => x.Remove(appointment), Times.Once);
        _appointmentContextMock.Object.Appointments.Should().NotContain(appointment);
    }

    [Fact]
    public async Task CreateAppointment_ShouldAddItemToCollection_WhenAppointmentProvided()
    {
        // arrange
        var appointment = new Data.Entities.Appointment
        {
            Id = 3,
            Date = DateTime.Today,
            Hour = _availableHours[2],
            UserId = 1,
            EmployeeId = _employeeId
        };

        // act
        await _appointmentService.Create(appointment);

        // assert
        _appointmentContextMock.Object.Appointments.Should().Contain(appointment);
    }

    [Fact]
    public async Task GetAllForUser_ShouldReturnAllAppointments_WhenUserIdIsProvided()
    {
        // arrange
        var userId = 1;

        // act
        var result = await _appointmentService.GetAllForUser(userId);

        // assert
        result.Count.Should().Be(
            _appointmentContextMock.Object.Appointments!
            .Where(x => x.UserId == userId)
            .ToList()
            .Count);
    }
}
