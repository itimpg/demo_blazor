using OFM.SellerPortal.Models.Charts;

namespace OFM.SellerPortal.Helpers.Interfaces
{
    public interface IUIHelper
    {
        Task GenerateChart(ChartConfig config);
    }
}
