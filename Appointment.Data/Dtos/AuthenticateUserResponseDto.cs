using Appointment.Data.Enums;

namespace Appointment.Data.Dtos;

public class AuthenticateUserResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public UserRoleEnum Role { get; set; }
}
