using Appointment.Data.Enums;

namespace Appointment.Client.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public UserRoleEnum Role { get; set; } = UserRoleEnum.User;
    }
}