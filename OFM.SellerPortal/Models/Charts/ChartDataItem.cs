using System.Drawing;

namespace OFM.SellerPortal.Models.Charts
{
    public class ChartDataItem
    {
        public string Name { get; private set; }
        public decimal Value { get; private set; }
        public string BackgroundColor { get; private set; }
        public string BorderColor { get; private set; }

        public ChartDataItem(string name, decimal value, Color backgroundColor)
        {
            Name = name;
            Value = value;
            BackgroundColor = $"rgba({backgroundColor.R}, {backgroundColor.G}, {backgroundColor.B}, 0.2)";
            BorderColor = $"rgba({backgroundColor.R}, {backgroundColor.G}, {backgroundColor.B})";
        }
    }
}
