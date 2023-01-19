using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace OFM.SellerPortal.Cores
{
    public class LanguageSelectorBase : ComponentBase
    {
        [Inject]
        IJSRuntime JSRuntime { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected CultureInfo[] supportedLanguages = new[]
        {
            new CultureInfo("en-US"),
            new CultureInfo("th-TH"),
        };
        protected CultureInfo Culture
        {
            get => CultureInfo.CurrentCulture;
            set
            {
                if (CultureInfo.CurrentCulture != value)
                {
                    var js = (IJSInProcessRuntime)JSRuntime;
                    js.InvokeVoid("appCulture.set", value.Name);
                    NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
                }
            }
        }
    }
}
