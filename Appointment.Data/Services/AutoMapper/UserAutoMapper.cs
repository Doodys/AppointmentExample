using AutoMapper;
using Appointment.Data.Dtos;
using Appointment.Data.Entities;
using Appointment.Data.Models.Account;

namespace Appointment.Data.Services.AutoMapper;

public class UserAutoMapper : Profile
{
    public UserAutoMapper()
    {
        CreateMap<User, AuthenticateUserResponseDto>();
        CreateMap<AuthenticateUserResponseDto, User>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

        CreateMap<User, AddUserDto>();

        CreateMap<AddUserDto, User>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
    }
}
