using System.Collections.Generic;

namespace BrentWiels.Viewmodels
{
    public class DocumentViewModel : ModelBase
    {
        public string FileName { get; set; }
        public KlantViewModel Klant { get; set; }
        public List<WerkLineViewModel> Werklijnen { get; set; }
        public decimal Btw { get; set; }

        public decimal TotalePrijs {
            get {
                var prijs = 0m;
                this.Werklijnen.ForEach(x => prijs += x.BrutoPrijs);
                return prijs;
            }
        }
    }
}