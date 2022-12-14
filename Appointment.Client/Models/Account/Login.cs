using System.ComponentModel.DataAnnotations;

namespace Appointment.Client.Models.Account
{
    public class Login
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}