using DoctorAppointment.Data.Enums;

namespace DoctorAppointment.Data.Dtos;

public class AuthenticateUserResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public UserRoleEnum Role { get; set; }
}
