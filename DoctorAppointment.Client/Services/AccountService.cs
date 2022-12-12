using DoctorAppointment.Client.Models;
using DoctorAppointment.Client.Models.Account;
using Microsoft.AspNetCore.Components;

namespace DoctorAppointment.Client.Services
{
    public class AccountService : IAccountService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private readonly string _userKey = "user";

        public User User { get; private set; }

        public AccountService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        ) {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<User>(_userKey);
        }

        public async Task Login(Login model)
        {
            User = await _httpService.Post<User>("/AuthenticateUser", model);
            await _localStorageService.SetItem(_userKey, User);
        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem(_userKey);
            _navigationManager.NavigateTo("");
        }

        public async Task Register(AddUser model)
        {
            await _httpService.Post("/CreateUser", model);
        }

        public async Task<IList<User>> GetAll()
        {
            return await _httpService.Get<IList<User>>("/User");
        }

        public async Task<User> GetById(string id)
        {
            return await _httpService.Get<User>($"/User/{id}");
        }

        public async Task Update(string id, EditUser model)
        {
            await _httpService.Put($"/User/{id}", model);

            // update stored user if the logged in user updated their own record
            if (Convert.ToInt32(id) == User.Id) 
            {
                // update local storage
                User.Name = model.FirstName;
                User.Surname = model.LastName;
                await _localStorageService.SetItem(_userKey, User);
            }
        }

        public async Task Delete(string id)
        {
            await _httpService.Delete($"/users/{id}");

            // auto logout if the logged in user deleted their own record
            if (Convert.ToInt32(id) == User.Id)
                await Logout();
        }
    }
}