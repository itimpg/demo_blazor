using Blazored.Modal;
using Blazored.Modal.Services;
using OFM.SellerPortal.Enums;
using OFM.SellerPortal.Models.Charts;
using OFM.SellerPortal.Shared.ModalContents;

namespace OFM.SellerPortal.Helpers.Interfaces
{
    public interface IUIHelper
    {
        Task GenerateChart(ChartConfig config);

        Task ShowSuccessMessage(string title, string message);
        Task ShowErrorMessage(string title, string message);
        Task ShowWarningMessage(string title, string message);
        Task<bool> ShowConfirmationMessageAsync(string title, string message);
    }
}
