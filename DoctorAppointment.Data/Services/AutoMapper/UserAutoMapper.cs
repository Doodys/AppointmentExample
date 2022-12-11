using AutoMapper;
using DoctorAppointment.Data.Dtos;
using DoctorAppointment.Data.Entities;
using DoctorAppointment.Data.Models.Account;

namespace DoctorAppointment.Data.Services.AutoMapper;

public class UserAutoMapper : Profile
{
    public UserAutoMapper()
    {
        CreateMap<User, AuthenticateUserResponseDto>();
        CreateMap<User, AddUserDto>();

        CreateMap<AddUserDto, User>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
    }
}
