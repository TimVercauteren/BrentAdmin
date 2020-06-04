using System;

namespace BrentWiels.Viewmodels
{
    public class OfferteViewModel : DocumentViewModel
    {
        public string OfferteNummer { get; set; }
        public DateTime VervalDatum { get; set; }
        public int VersieNummer { get; set; }
        public DateTime Datum { get; set; }
    }
}
