using System.ComponentModel.DataAnnotations;

namespace DoctorAppointment.Data.Dtos;

public class AuthenticateUserDto
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
