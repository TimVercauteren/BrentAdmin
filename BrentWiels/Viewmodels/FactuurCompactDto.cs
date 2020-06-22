using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrentWiels.Viewmodels
{
    public class FactuurCompactDto
    {
        public string FactuurNummer { get; set; }
        public string OfferteNummer { get; set; }
        public string Datum { get; set; }
        public bool IsDownloaded { get; set; }
        public int Id { get; set; }
    }
}
