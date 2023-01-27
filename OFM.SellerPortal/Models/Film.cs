using OFM.SellerPortal.Models.Charts;

namespace OFM.SellerPortal.Models
{
    public class Film
    {
        public string Title { get; set; }
        public int Year { get; set; }
    }

    public class MyFormModel
    {
        public ChartDataItem SelectedFilm { get; set; }
    }
}
