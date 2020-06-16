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

        public static string OfferteNummerCell = "D6";
        public static string DatumCell = "D4";
        public static string VervalDatumCell = "D5";
        public static string KlantNaamCell = "D9";
        public static string KlantStraatNummerCell = "D10";
        public static string KlantPostcodeGemeenteCell = "D11";
        public static string KlantRefCell = "D12";
        public static string KlantTelefoonCell = "D13";
        public static string KlantBtwCell = "D14";
        public static string KlantEmailCell = "D15";

        public static string Items1Cell = "A24";
        public static string Items2Cell = "A25";
        public static string Items3Cell = "A26";
        public static string Items4Cell = "A27";
        public static string Items5Cell = "A28";
        public static string Items6Cell = "A29";
        public static string ItemFactuurCell = "A30";

        public static string Items1PrijsCell = "D24";
        public static string Items2PrijsCell = "D25";
        public static string Items3PrijsCell = "D26";
        public static string Items4PrijsCell = "D27";
        public static string Items5PrijsCell = "D28";
        public static string Items6PrijsCell = "D29";
        public static string ItemFactuurPrijsCell = "D30";

        public static string TypeCell = "D1";

        public static string TotaalNettoPrijsCell = "D31";
        public static string PrijsIfBtw6Cell = "D33";
        public static string PrijsIfBtw21Cell = "D34";
        public static string PrijsIfBtw0Cell = "D35";
        public static string TotaalPrijsIncBtwCell = "D36";
        public static string PrijsVoorschotCell = "D39";
        public static string PrijsLeftOverCell = "D40";
    }
}