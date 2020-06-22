using DataLayer.Interfaces;
using Documents.DTO;
using Documents.Interfaces;
using Documents.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Documents.Implementations
{
    public class DocumentGenerator : IDocumentGenerator
    {
        public virtual string  FillDocumentTemplate(DocumentDto dto)
        {
            var template = Resources.DocumentTemplate;

            //template.Replace(Ost.VervalDatum, dto.VervalDatum);
            //template.Replace(Ost.Type, Offerte);
            //template = template.Replace(Ost.OfferteNummer, dto.OfferteNummer);



            template = template.Replace(Ost.Datum, dto.Datum);
            template = template.Replace(Ost.KlantNaam, dto.KlantNaam);
            template = template.Replace(Ost.KlantStraatNummer, dto.KlantStraatNummer);
            template = template.Replace(Ost.KlantPostCodeGemeente, dto.KlantPostcodeGemeente);
            template = template.Replace(Ost.KlantRef, dto.KlantRef);
            template = template.Replace(Ost.KlantTelefoon, dto.KlantTelefoon);
            template = template.Replace(Ost.KlantBtw, dto.KlantBtw);
            template = template.Replace(Ost.KlantEmail, dto.KlantEmail);

            template = template.Replace(Ost.Item1, dto.Item1);
            template = template.Replace(Ost.Item2, dto.Item2);
            template = template.Replace(Ost.Item3, dto.Item3);
            template = template.Replace(Ost.Item4, dto.Item4);
            template = template.Replace(Ost.Item5, dto.Item5);
            template = template.Replace(Ost.Item6, dto.Item6);

            template = template.Replace(Ost.Item1Prijs, dto.Item1Prijs);
            template = template.Replace(Ost.Item2Prijs, dto.Item2Prijs);
            template = template.Replace(Ost.Item3Prijs, dto.Item3Prijs);
            template = template.Replace(Ost.Item4Prijs, dto.Item4Prijs);
            template = template.Replace(Ost.Item5Prijs, dto.Item5Prijs);
            template = template.Replace(Ost.Item6Prijs, dto.Item6Prijs);

            template = template.Replace(Ost.TotaalNettoPrijs, dto.TotaalNettoPrijs);
            template = template.Replace(Ost.BTW6, dto.PrijsIfBtw6);
            template = template.Replace(Ost.BTW21, dto.PrijsIfBtw21);
            template = template.Replace(Ost.Medecontractant, dto.PrijsIfBtw0);
            template = template.Replace(Ost.TotaalPrijsIncBtw, dto.TotaalPrijsIncBtw);

            return template;
        }
    }

    static class Ost
    {
        public static string Type = "{{Type}}";
        public static string Datum = "{{Datum}}";
        public static string VervalDatum = "{{VervalDatum}}";
        public static string OfferteNummer = "{{OfferteNummer}}";
        public static string KlantNaam = "{{KlantNaam}}";
        public static string KlantStraatNummer = "{{KlantStraatNummer}}";
        public static string KlantPostCodeGemeente = "{{KlantPostcodeGemeente}}";
        public static string KlantRef = "{{KlantRef}}";
        public static string KlantTelefoon = "{{KlantTelefoon}}";
        public static string KlantBtw = "{{KlantBtw}}";
        public static string KlantEmail = "{{KlantEmail}}";

        public static string Item1 = "{{Item1}}";
        public static string Item2 = "{{Item2}}";
        public static string Item3 = "{{Item3}}";
        public static string Item4 = "{{Item4}}";
        public static string Item5 = "{{Item5}}";
        public static string Item6 = "{{Item6}}";
        public static string ItemFactuur = "{{FactuurItem}}";

        public static string Item1Prijs = "{{Item1Prijs}}";
        public static string Item2Prijs = "{{Item2Prijs}}";
        public static string Item3Prijs = "{{Item3Prijs}}";
        public static string Item4Prijs = "{{Item4Prijs}}";
        public static string Item5Prijs = "{{Item5Prijs}}";
        public static string Item6Prijs = "{{Item6Prijs}}";
        public static string ItemFactuurPrijs = "{{FactuurItemPrijs}}";


        public static string TotaalNettoPrijs = "{{TotaalNettoPrijs}}";
        public static string BTW6 = "{{PrijsIfBtw6}}";
        public static string BTW21 = "{{PrijsIfBtw21}}";
        public static string Medecontractant = "{{PrijsIfBtw0}}";
        public static string TotaalPrijsIncBtw = "{{TotaalPrijsIncBtw}}";
        public static string PrijsVoorschot = "{{PrijsVoorschot}}";
        public static string PrijsLeftOver = "{{PrijsLeftOver}}";


    }
}
