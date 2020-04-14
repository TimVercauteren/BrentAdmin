using System;
using System.Collections.Generic;
using System.Text;
using DocumentFormat.OpenXml.CustomProperties;

namespace Documents.DTO
{
    public class OfferteDTO
    {
        public string OfferteNummer { get; set; }
        public static string OfferteNummerCell = "D4";

        public string Datum { get; set; }
        public static string DatumCell = "D5";

        public string VervalDatum { get; set; }
        public static string VervalDatumCell = "D6";

        public string KlantNaam { get; set; }
        public static string KlantNaamCell = "D9";

        public string KlantStraatNummer { get; set; }
        public static string KlantStraatNummerCell = "D10";

        public string KlantPostcodeGemeente { get; set; }
        public static string KlantPostcodeGemeenteCell = "D11";

        public string KlantRef { get; set; }
        public static string KlantRefCell = "D12";

        public string KlantTelefoon { get; set; }
        public static string KlantTelefoonCell = "D13";

        public string KlantBtw { get; set; }
        public static string KlantBtwCell = "D14";

        public string KlantEmail { get; set; }
        public static string KlantEmailCell = "D15";

        public IList<string> WorkItems { get; set; }

        public string Item1 { get; set; } = "";
        public static string Items1Cell = "A24";

        public string Item2 { get; set; } = "";
        public static string Items2Cell = "A25";

        public string Item3 { get; set; } = "";
        public static string Items3Cell = "A26";

        public string Item4 { get; set; } = "";
        public static string Items4Cell = "A27";

        public string Item5 { get; set; } = "";
        public static string Items5Cell = "A28";

        public string Item6 { get; set; } = "";
        public static string Items6Cell = "A29";


        public string TotaalNettoPrijs { get; set; }
        public static string TotaalNettoPrijsCell = "D31";

        public string PrijsIfBtw6 { get; set; }
        public static string PrijsIfBtw6Cell = "D33";

        public string PrijsIfBtw21 { get; set; }
        public static string PrijsIfBtw21Cell = "D34";

        public string PrijsIfBtw0 { get; set; }
        public static string PrijsIfBtw0Cell = "D35";

        public string TotaalPrijsIncBtw { get; set; }
        public static string TotaalPrijsIncBtwCell = "D36";

        public string PrijsVoorschot { get; set; }
        public static string PrijsVoorschotCell = "D39";

        public string PrijsLeftOver { get; set; }
        public static string PrijsLeftOverCell = "D40";

    }
}
