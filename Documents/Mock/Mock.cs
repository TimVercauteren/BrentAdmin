using Documents.DTO;
using System;

namespace Documents.Mock
{
    public static class Mock
    {
        public static OfferteDTO Offerte()
        {
            return new OfferteDTO
            {
                Datum = DateTime.Today.ToShortDateString(),
                VervalDatum = DateTime.Today.AddDays(10).ToShortDateString(),
                Item1 = "Werkitem 1",
                Item2 = "Werkitem 2",
                Item3 = "Werkitem 3",
                Item4 = "Werkitem 4",
                Item5 = "Werkitem 5",
                Item6 = "Werkitem 6",
                KlantBtw = "BE64 0458 1231 55456",
                KlantEmail = "email.klant@test.be",
                KlantNaam = "Testklant",
                KlantPostcodeGemeente = "9240",
                KlantRef = "Testklant Ref",
                KlantStraatNummer = "90",
                KlantTelefoon = "052449172",
                OfferteNummer = "Offerte1",
                PrijsIfBtw0 = "200",
                PrijsIfBtw21 = "250",
                PrijsIfBtw6 = "225",
                PrijsLeftOver = "25",
                PrijsVoorschot = "125",
                TotaalNettoPrijs = "120",
                TotaalPrijsIncBtw = "250"
            };
        }
    }
}
