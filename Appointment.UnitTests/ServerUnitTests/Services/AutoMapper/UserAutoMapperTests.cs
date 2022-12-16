using Appointment.Data.Services.AutoMapper;
using AutoMapper;
using Xunit;
using Appointment.Data.Dtos;
using Appointment.Data.Entities;
using Appointment.Data.Models.Account;
using FluentAssertions;

namespace Appointment.UnitTests.ServerUnitTests.Services.AutoMapper;

// TO-DO-TEST pozostałe 3 mappery z klasy UserAutoMapper w klasie testowej poniżej

public class UserAutoMapperTests
{
    private readonly IMapper _mapper;

    public UserAutoMapperTests()
    {
        var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<UserAutoMapper>());
        _mapper = mapperConfiguration.CreateMapper();
    }

    [Fact]
    public void CreateMap_ShouldMapUserToAuthenticateUserResponseDto_WhenUserIsProvided()
    {
        // arrange
        var user = new User()
        {
            Name = "Test",
            Surname = "Testowitch",
            Login = "Test",
            Password = "Test123"
        };

        // act
        var mappedUser = _mapper.Map<AuthenticateUserResponseDto>(user);

        // assert
        mappedUser.Name.Should().BeEquivalentTo(user.Name);
        mappedUser.Surname.Should().BeEquivalentTo(user.Surname);
        mappedUser.Id.Should().Be(user.Id);
        mappedUser.Role.Should().Be(user.Role);
    }
}
