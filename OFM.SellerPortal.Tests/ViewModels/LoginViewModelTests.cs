using Blazored.LocalStorage;
using FakeItEasy;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using OFM.SellerPortal.Services.Interfaces;
using OFM.SellerPortal.Shared.Models.Auth.Login;
using OFM.SellerPortal.Tests.Fakes;
using OFM.SellerPortal.ViewModels;
using OFM.SellerPortal.ViewModels.Interfaces;

namespace OFM.SellerPortal.Tests.ViewModels
{
    public class LoginViewModelTests
    {
        private readonly IAuthService _authService;
        private readonly ILocalStorageService _localStorageService;
        private readonly NavigationManager _navigationManager;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        private ILoginViewModel GetInstance()
        {
            return new LoginViewModel(_authService, _localStorageService, _navigationManager, _authenticationStateProvider);
        }

        public LoginViewModelTests()
        {
            _authService = A.Fake<IAuthService>();
            _localStorageService = A.Fake<ILocalStorageService>();
            _navigationManager = A.Fake<FakeNavigationManager>();
            _authenticationStateProvider = A.Fake<AuthenticationStateProvider>();
        }

        [Fact]
        public async Task SubmitLogin_Should_SaveUserLoginDataIntoLocalStorage_When_LoginSuccess()
        {
            var viewModel = GetInstance();
            viewModel.Model.UserName = "Test@test.com";
            viewModel.Model.Password = "password";

            await viewModel.SubmitLogin();

            A.CallTo(() => _authService.Login(
                A<LoginRequest>.That.Matches(x=> 
                    x.UserName == "Test@test.com" 
                    && x.Password == "password")))
                .MustHaveHappenedOnceExactly();

            A.CallTo(() => _localStorageService.SetItemAsync("authToken", A<string>._, A<CancellationToken>._)).MustHaveHappenedOnceExactly();

            A.CallTo(() => _authenticationStateProvider.GetAuthenticationStateAsync()).MustHaveHappenedOnceExactly();
        }
    }
}
