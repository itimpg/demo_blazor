using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using OFM.SellerPortal.Models;
using OFM.SellerPortal.Services.Interfaces;
using OFM.SellerPortal.Shared.Models.Auth.Login;
using OFM.SellerPortal.ViewModels.Interfaces;

namespace OFM.SellerPortal.ViewModels
{
    public class LoginViewModel : ILoginViewModel
    {
        public LoginModel Model { get; } = new LoginModel();

        private readonly IAuthService _authService;
        private readonly ILocalStorageService _localStorageService;
        private readonly NavigationManager _navigationManager;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public LoginViewModel(
            IAuthService authService,
            ILocalStorageService localStorage,
            NavigationManager navigationManager,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _authService = authService;
            _localStorageService = localStorage;
            _navigationManager = navigationManager;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task SubmitLogin()
        {
            var result = await _authService.Login(
                new LoginRequest { UserName = Model.UserName, Password = Model.Password });

            await _localStorageService.SetItemAsync("authToken", result.UserData);
            await _authenticationStateProvider.GetAuthenticationStateAsync();
            _navigationManager.NavigateTo("");
        }
    }
}
