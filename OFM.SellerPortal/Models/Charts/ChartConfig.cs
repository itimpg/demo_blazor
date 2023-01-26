using System.Text.Json.Serialization;
using OFM.SellerPortal.Enums;

namespace OFM.SellerPortal.Models.Charts
{
    public class ChartConfig
    {
        private ChartConfig() { }

        public string ChartId { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("labels")]
        public string[] Labels { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("data")]
        public decimal[] Data { get; set; }

        [JsonPropertyName("backgroundColor")]
        public string[] BackgroundColors { get; set; }

        [JsonPropertyName("borderColor")]
        public string[] BorderColors { get; set; }

        [JsonPropertyName("borderWidth")]
        public int BorderWitdh { get; set; }

        public static ChartConfig Create(
            string chartId,
            ChartTypes type,
            IEnumerable<ChartDataItem> chartDataItems,
            string dataLabel = "",
            int borderWidth = 1)
        {
            return new ChartConfig
            {
                ChartId = chartId,
                Type = type,
                Labels = chartDataItems.Select(x => x.Name).ToArray(),
                Label = dataLabel,
                Data = chartDataItems.Select(x => x.Value).ToArray(),
                BackgroundColors = chartDataItems.Select(x => x.BackgroundColor).ToArray(),
                BorderColors = chartDataItems.Select(x => x.BorderColor).ToArray(),
                BorderWitdh = borderWidth
            };
        }
    }
}
