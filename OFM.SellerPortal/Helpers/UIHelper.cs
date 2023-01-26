using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.JSInterop;
using OFM.SellerPortal.Enums;
using OFM.SellerPortal.Helpers.Interfaces;
using OFM.SellerPortal.Models.Charts;
using OFM.SellerPortal.Shared.ModalContents;
using System.Reflection;

namespace OFM.SellerPortal.Helpers
{
    public class UIHelper : IUIHelper
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly IModalService _modalService;

        public UIHelper(IJSRuntime jSRuntime, IModalService modalService)
        {
            _jsRuntime = jSRuntime;
            _modalService = modalService;
        }

        public async Task GenerateChart(ChartConfig config)
        {
            await _jsRuntime.InvokeVoidAsync("GeneratePieChart", config);
        }

        private Task<ModalResult> ShowMessage(string title, string message, ModalTypes modalType)
        {
            var parameters = new ModalParameters()
              .Add(nameof(MessageModal.Message), message)
              .Add(nameof(MessageModal.ModalType), modalType);

            var modal = _modalService.Show<MessageModal>(title, parameters);
            return modal.Result;
        }

        public Task ShowSuccessMessage(string title, string message)
        {
            return ShowMessage(title, message, ModalTypes.Success);
        }

        public Task ShowErrorMessage(string title, string message)
        {
            return ShowMessage(title, message, ModalTypes.Error);
        }

        public Task ShowWarningMessage(string title, string message)
        {
            return ShowMessage(title, message, ModalTypes.Warning);
        }

        public async Task<bool> ShowConfirmationMessageAsync(string title, string message)
        {
            var result = await ShowMessage(title, message, ModalTypes.Confirm);

            return result.Confirmed;
        }
    }
}
