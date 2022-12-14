using AutoMapper;
using Appointment.Data.Contexts;
using Appointment.Data.Dtos;
using Appointment.Data.Entities;
using Appointment.Data.Helpers;
using Appointment.Data.Models.Account;
using Appointment.Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Data.Services;

#pragma warning disable CS8603

public class UserService : IUserService
{
    private readonly UserContext _userContext;
    private readonly AppointmentContext _appointmentContext;
    private readonly IMapper _mapper;

    public UserService(UserContext userContext, AppointmentContext appointmentContext, IMapper mapper)
    {
        _userContext = userContext;
        _appointmentContext = appointmentContext;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task Create(AddUserDto user)
    {
        var newUser = _mapper.Map<User>(user);

        var userExistsCheck = await _userContext.Users
            .FirstOrDefaultAsync(x => x.Login == newUser.Login);

        if (userExistsCheck != null)
            throw new AppException($"User {newUser.Login} already exists!");

        await _userContext.Users!.AddAsync(newUser);
        await _userContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task<List<User>> GetAll()
    {
        return await _userContext.Users!
                .ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<User> GetById(int id)
    {
        return await _userContext.Users!
                .Where(v => v.Id == id)
                .FirstOrDefaultAsync();
    }

    /// <inheritdoc/>
    public async Task DeleteById(int id)
    {
        var userAppointments = await _appointmentContext.Appointments!
            .Where(v => v.UserId == id)
            .ToListAsync();

        foreach (var appointment in userAppointments)
        {
            _appointmentContext.Appointments!.Remove(appointment);
        }

        var user = await GetById(id);

        _userContext.Users!.Remove(user);

        await _userContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task UpdateById(int id, UserDto user)
    {
        // assume Entity base class have an Id property for all items
        var entity = _userContext.Users!.Find(id);

        if (entity == null)
        {
            return;
        }

        entity.Name = user.Name;
        entity.Surname = user.Surname;

        _userContext.Users.Update(entity);

        await _userContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public AuthenticateUserResponseDto Authenticate(AuthenticateUserDto userDto)
    {
        var user = _userContext.Users.SingleOrDefault(x => x.Login == userDto.Username);

        if (user is null || user.Password != userDto.Password)
        {
            throw new AppException("Username or password is incorrect");
        }

        var response = _mapper.Map<AuthenticateUserResponseDto>(user);
        return response;
    }
}
