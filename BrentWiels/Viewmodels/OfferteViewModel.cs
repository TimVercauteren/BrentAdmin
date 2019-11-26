using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrentWiels.Viewmodels
{
    public class OfferteViewModel : DocumentViewModel
    {
        public string OfferteNummer { get; set; }
        public DateTime VervalDatum { get; set; }
        public int VersieNummer { get; set; }
    }
}
