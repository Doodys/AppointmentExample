using DoctorAppointment.Data.Enums;

namespace DoctorAppointment.Client.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public UserRoleEnum Role { get; set; } = UserRoleEnum.User;
    }
}