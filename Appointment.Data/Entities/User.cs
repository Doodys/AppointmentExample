using Appointment.Data.Enums;

namespace Appointment.Data.Entities;

public class User
{
    public int Id { get; set; } = 0;
    public string Name { get; set; }
    public string Surname{ get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public UserRoleEnum Role { get; set; } = UserRoleEnum.User;
}
