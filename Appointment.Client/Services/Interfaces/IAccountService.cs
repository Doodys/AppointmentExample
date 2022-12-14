using Appointment.Client.Models;
using Appointment.Client.Models.Account;

namespace Appointment.Client.Services.Interfaces;

public interface IAccountService
{
    User User { get; }
    Task Initialize();
    Task Login(Login model);
    Task Logout();
    Task Register(AddUser model);
    Task<IList<User>> GetAll();
    Task<User> GetById(string id);
    Task Delete(int id);
}
