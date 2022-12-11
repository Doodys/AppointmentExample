using DoctorAppointment.Data.Enums;

namespace DoctorAppointment.Data.Dtos;

public class UserDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public UserRoleEnum Role { get; set; }
}
