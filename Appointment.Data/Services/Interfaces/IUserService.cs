using Appointment.Data.Dtos;
using Appointment.Data.Entities;
using Appointment.Data.Models.Account;

namespace Appointment.Data.Services.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Get all users
    /// </summary>
    /// <returns></returns>
    Task<List<User>> GetAll();

    /// <summary>
    /// Get User by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<User> GetById(int id);

    /// <summary>
    /// Create User
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task Create(AddUserDto user);

    /// <summary>
    /// Delete user by given id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteById(int id);

    /// <summary>
    /// Update user
    /// </summary>
    /// <param name="id"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    Task UpdateById(int id, UserDto user);

    /// <summary>
    /// Authenticate login request from user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    AuthenticateUserResponseDto Authenticate(AuthenticateUserDto user);
}
