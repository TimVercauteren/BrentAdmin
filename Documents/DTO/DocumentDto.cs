using DataLayer.Entities;
using System.Collections.Generic;

namespace Documents.DTO
{
    public abstract class DocumentDto
    {
        public string OfferteNummer { get; set; }
        public string Datum { get; set; }
        public string KlantNaam { get; set; }
        public string KlantStraatNummer { get; set; }
        public string KlantPostcodeGemeente { get; set; }
        public string KlantRef { get; set; }
        public string KlantTelefoon { get; set; }
        public string KlantBtw { get; set; }
        public string KlantEmail { get; set; }
        public IList<WerkLine> WorkItems { get; set; }
        public string Item1 { get; set; } = "";
        public string Item2 { get; set; } = "";
        public string Item3 { get; set; } = "";
        public string Item4 { get; set; } = "";
        public string Item5 { get; set; } = "";
        public string Item6 { get; set; } = "";

        public string Item1Prijs { get; set; } = "";
        public string Item2Prijs { get; set; } = "";
        public string Item3Prijs { get; set; } = "";
        public string Item4Prijs { get; set; } = "";
        public string Item5Prijs { get; set; } = "";
        public string Item6Prijs { get; set; } = "";

        public string TotaalNettoPrijs { get; set; }
        public string PrijsIfBtw6 { get; set; }
        public string PrijsIfBtw21 { get; set; }
        public string PrijsIfBtw0 { get; set; }
        public string TotaalPrijsIncBtw { get; set; }
    }
}