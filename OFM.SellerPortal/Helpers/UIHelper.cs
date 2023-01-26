using Microsoft.JSInterop;
using OFM.SellerPortal.Helpers.Interfaces;
using OFM.SellerPortal.Models.Charts;

namespace OFM.SellerPortal.Helpers
{
    public class UIHelper : IUIHelper
    {
        private readonly IJSRuntime _jsRuntime;

        public UIHelper(IJSRuntime jSRuntime)
        {
            _jsRuntime = jSRuntime;
        }

        public async Task GenerateChart(ChartConfig config)
        {
            await _jsRuntime.InvokeVoidAsync("GeneratePieChart", config);
        }
    }
}
