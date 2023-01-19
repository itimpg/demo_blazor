using OFM.SellerPortal.Models;

namespace OFM.SellerPortal.ViewModels.Interfaces
{
    public interface ILoginViewModel : IViewModel
    {
        public LoginModel Model { get; }

        Task SubmitLogin();
    }
}
