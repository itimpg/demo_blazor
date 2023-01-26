using Ardalis.SmartEnum;

namespace OFM.SellerPortal.Models.Charts
{
    public class ChartTypes : SmartEnum<ChartTypes, string>
    {
        public static readonly ChartTypes Bar = new ChartTypes("Bar", "bar");
        public static readonly ChartTypes Pie = new ChartTypes("Pie", "pie");
        public static readonly ChartTypes Doughnut = new ChartTypes("Doughnut", "doughnut");

        private ChartTypes(string name, string value) : base(name, value)
        {
        }
    }
}
