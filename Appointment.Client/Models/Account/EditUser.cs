using System.ComponentModel.DataAnnotations;

namespace Appointment.Client.Models.Account;

public class EditUser
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public EditUser() { }

    public EditUser(User user)
    {
        FirstName = user.Name;
        LastName = user.Surname;
    }
}