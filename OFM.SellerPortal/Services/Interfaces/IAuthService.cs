using OFM.SellerPortal.Models;
using OFM.SellerPortal.Shared.Models.Auth.Login;

namespace OFM.SellerPortal.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task Logout();
    }
}
