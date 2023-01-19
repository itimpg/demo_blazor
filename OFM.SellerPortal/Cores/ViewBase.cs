using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace OFM.SellerPortal.Cores
{
    public abstract class ViewBase<IViewModel> : ComponentBase
    { 
        [Inject]
        protected IStringLocalizer<Resources.App> Localizer { get; set; } = default!;

        [Inject]
        public IViewModel ViewModel { get; set; } = default!;
    }
}
