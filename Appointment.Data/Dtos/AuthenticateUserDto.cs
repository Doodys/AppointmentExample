using System.ComponentModel.DataAnnotations;

namespace Appointment.Data.Dtos;

public class AuthenticateUserDto
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
