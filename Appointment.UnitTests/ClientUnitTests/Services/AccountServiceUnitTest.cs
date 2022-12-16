using Appointment.Client.Models;
using Appointment.Client.Models.Account;
using Appointment.Client.Services;
using Appointment.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Moq;
using Xunit;

// TO-DO-TEST przyklad otestowanej klasy serwisu ze strony Clienta

namespace Appointment.UnitTests.ClientUnitTests.Services;

public class AccountServiceUnitTest
{
    [Fact]
    public async Task Initialize_ShouldGetUserFromLocalStorage_WhenCalled()
    {
        // Arrange
        var mockHttpService = new Mock<IHttpService>();
        var mockNavigationManager = new Mock<NavigationManager>();
        var mockLocalStorageService = new Mock<ILocalStorageService>();
        mockLocalStorageService
            .Setup(x => x.GetItem<User>("user"))
            .ReturnsAsync(new User { Name = "John", Surname = "Doe", Id = 1 });
        var accountService = new AccountService(
            mockHttpService.Object,
            mockNavigationManager.Object,
            mockLocalStorageService.Object);

        // Act
        await accountService.Initialize();

        // Assert
        Assert.Equal("John", accountService.User.Name);
        Assert.Equal("Doe", accountService.User.Surname);
        Assert.Equal(1, accountService.User.Id);
    }

    [Fact]
    public async Task Initialize_ShouldReturnDefault_WhenLocalStorageIsEmpty()
    {
        // Arrange
        var mockHttpService = new Mock<IHttpService>();
        var mockNavigationManager = new Mock<NavigationManager>();
        var mockLocalStorageService = new Mock<ILocalStorageService>();
        mockLocalStorageService
            .Setup(x => x.GetItem<User>("user"))
            .ReturnsAsync(new User());
        var accountService = new AccountService(
            mockHttpService.Object,
            mockNavigationManager.Object,
            mockLocalStorageService.Object);

        // Act
        await accountService.Initialize();

        // Assert
        Assert.Null(accountService.User.Name);
        Assert.Null(accountService.User.Surname);
        Assert.Equal(0, accountService.User.Id);
    }

    [Fact]
    public async void Login_ShouldCallLocalStorageSetItemWithCorrectKeyAndValue_WhenInvoked()
    {
        // Arrange
        var httpServiceMock = new Mock<IHttpService>();
        var navigationManagerMock = new Mock<NavigationManager>();
        var localStorageServiceMock = new Mock<ILocalStorageService>();
        var accountService = new AccountService(httpServiceMock.Object, navigationManagerMock.Object, localStorageServiceMock.Object);
        var loginModel = new Login { Username = "test@example.com", Password = "password" };
        var user = new User { Name = "John", Surname = "Doe", Id = 1 };
        httpServiceMock
            .Setup(x => x.Post<User>("/AuthenticateUser", loginModel))
            .ReturnsAsync(user);

        // Act
        await accountService.Login(loginModel);

        // Assert
        localStorageServiceMock.Verify(x => x.SetItem("user", user), Times.Once);
    }

    [Fact]
    public async void Login_ShouldSetUserPropertyToCorrectValue_WhenInvoked()
    {
        // Arrange
        var httpServiceMock = new Mock<IHttpService>();
        httpServiceMock.Setup(x => x.Post<User>("/AuthenticateUser", It.IsAny<Login>()))
            .ReturnsAsync(new User { Name = "John", Surname = "Doe", Id = 1 });
        var navigationManagerMock = new Mock<NavigationManager>();
        var localStorageServiceMock = new Mock<ILocalStorageService>();
        var accountService = new AccountService(httpServiceMock.Object, navigationManagerMock.Object, localStorageServiceMock.Object);
        var loginModel = new Login { Username = "test@example.com", Password = "password" };

        // Act
        await accountService.Login(loginModel);

        // Assert
        Assert.Equal("John", accountService.User.Name);
        Assert.Equal("Doe", accountService.User.Surname);
    }

    [Fact]
    public async void Login_ShouldCallHttpServicePostWithCorrectUriAndBody_WhenInvoked()
    {
        // Arrange
        var httpServiceMock = new Mock<IHttpService>();
        var navigationManagerMock = new Mock<NavigationManager>();
        var localStorageServiceMock = new Mock<ILocalStorageService>();
        var accountService = new AccountService(httpServiceMock.Object, navigationManagerMock.Object, localStorageServiceMock.Object);
        var loginModel = new Login { Username = "test@example.com", Password = "password" };

        // Act
        await accountService.Login(loginModel);

        // Assert
        httpServiceMock.Verify(x => x.Post<User>("/AuthenticateUser", loginModel), Times.Once);
    }

    [Fact]
    public async void Login_ShouldThrowException_WhenPostReturnsNonSuccessStatusCode()
    {
        // Arrange
        var httpServiceMock = new Mock<IHttpService>();
        httpServiceMock.Setup(x => x.Post<User>("/AuthenticateUser", It.IsAny<Login>()))
            .ReturnsAsync(() => throw new Exception("Error message"));
        var navigationManagerMock = new Mock<NavigationManager>();
        var localStorageServiceMock = new Mock<ILocalStorageService>();
        var accountService = new AccountService(httpServiceMock.Object, navigationManagerMock.Object, localStorageServiceMock.Object);
        var loginModel = new Login { Username = "test@example.com", Password = "password" };

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => accountService.Login(loginModel));
    }

    [Fact]
    public async Task Logout_ShouldSetUserToNull_WhenCalled()
    {
        // Arrange
        var mockHttpService = new Mock<IHttpService>();
        var mockNavigationManager = new Mock<NavigationManager>();
        var mockLocalStorageService = new Mock<ILocalStorageService>();
        var accountService = new AccountService(mockHttpService.Object, mockNavigationManager.Object, mockLocalStorageService.Object);

        // Act
        IgnoreExceptions(async () => await accountService.Logout());

        // Assert
        Assert.Null(accountService.User);
    }

    [Fact]
    public async Task Logout_ShouldCallRemoveItem_WhenCalled()
    {
        // Arrange
        var mockHttpService = new Mock<IHttpService>();
        var mockNavigationManager = new Mock<NavigationManager>();
        var mockLocalStorageService = new Mock<ILocalStorageService>();
        var accountService = new AccountService(mockHttpService.Object, mockNavigationManager.Object, mockLocalStorageService.Object);

        // Act
        IgnoreExceptions(async () => await accountService.Logout());

        // Assert
        mockLocalStorageService.Verify(x => x.RemoveItem("user"), Times.Once());
    }

    [Fact]
    public async void Register_ShouldCallHttpServicePostWithCorrectUriAndBody_WhenInvoked()
    {
        // Arrange
        var httpServiceMock = new Mock<IHttpService>();
        var navigationManagerMock = new Mock<NavigationManager>();
        var localStorageServiceMock = new Mock<ILocalStorageService>();
        var accountService = new AccountService(httpServiceMock.Object, navigationManagerMock.Object, localStorageServiceMock.Object);
        var addUserModel = new AddUser
        {
            FirstName = "John",
            LastName = "Doe",
            Username = "johndoe",
            Password = "password"
        };

        // Act
        await accountService.Register(addUserModel);

        // Assert
        httpServiceMock.Verify(x => x.Post("/CreateUser", addUserModel), Times.Once);
    }

    [Fact]
    public async void GetAll_ShouldCallHttpServicePostWithCorrectUriAndBody_WhenInvoked()
    {
        // Arrange
        var httpServiceMock = new Mock<IHttpService>();
        var navigationManagerMock = new Mock<NavigationManager>();
        var localStorageServiceMock = new Mock<ILocalStorageService>();
        var accountService = new AccountService(httpServiceMock.Object, navigationManagerMock.Object, localStorageServiceMock.Object);

        // Act
        await accountService.GetAll();

        // Assert
        httpServiceMock.Verify(x => x.Get<IList<User>>("/User"), Times.Once);
    }

    [Fact]
    public async void GetById_ShouldCallHttpServicePostWithCorrectUriAndBody_WhenInvoked()
    {
        // Arrange
        var httpServiceMock = new Mock<IHttpService>();
        var navigationManagerMock = new Mock<NavigationManager>();
        var localStorageServiceMock = new Mock<ILocalStorageService>();
        var accountService = new AccountService(httpServiceMock.Object, navigationManagerMock.Object, localStorageServiceMock.Object);

        // Act
        await accountService.GetById("1");

        // Assert
        httpServiceMock.Verify(x => x.Get<User>("/User/1"), Times.Once);
    }

    // there's no way of mocking and setup for NavigateTo from NavigationManager,
    // so we have to create a method to ignore NotSupportedException thrown by
    // NavigateTo and act normally for every other suspicious exception

    private void IgnoreExceptions(Action act)
    {
        try
        {
            act.Invoke();
        }
        catch(NotSupportedException) { }
    }
}
