using System.IO;
using ClosedXML.Excel;
using Documents.DTO;
using Documents.Interfaces;

namespace Documents
{
    public class OfferteGenerator : IOfferteGenerator
    {
        public OfferteGenerator()
        {

        }

        public static XLWorkbook GetOfferteTemplate()
        {
            const string fullpath = "Templates\\BrentOfferteTemplate.xlsx";
            var offerte = new XLWorkbook(fullpath);
            return offerte;
        }

        public byte[] FillTemplateWithOfferteData(OfferteDTO dataObject)
        {
            using var workbook = GetOfferteTemplate();
            workbook.Cell(OfferteDTO.DatumCell).Value = dataObject.Datum;

            workbook.Cell(OfferteDTO.Items1Cell).Value = dataObject.Item1;
            workbook.Cell(OfferteDTO.Items2Cell).Value = dataObject.Item2;
            workbook.Cell(OfferteDTO.Items3Cell).Value = dataObject.Item3;
            workbook.Cell(OfferteDTO.Items4Cell).Value = dataObject.Item4;
            workbook.Cell(OfferteDTO.Items5Cell).Value = dataObject.Item5;
            workbook.Cell(OfferteDTO.Items6Cell).Value = dataObject.Item6;

            workbook.Cell(OfferteDTO.KlantBtwCell).Value = dataObject.KlantBtw;
            workbook.Cell(OfferteDTO.KlantEmailCell).Value = dataObject.KlantEmail;
            workbook.Cell(OfferteDTO.KlantNaamCell).Value = dataObject.KlantNaam;
            workbook.Cell(OfferteDTO.KlantPostcodeGemeenteCell).Value = dataObject.KlantPostcodeGemeente;
            workbook.Cell(OfferteDTO.KlantRefCell).Value = dataObject.KlantRef;
            workbook.Cell(OfferteDTO.KlantStraatNummerCell).Value = dataObject.KlantStraatNummer;
            workbook.Cell(OfferteDTO.KlantTelefoonCell).Value = dataObject.KlantTelefoon;
            workbook.Cell(OfferteDTO.OfferteNummerCell).Value = dataObject.OfferteNummer;
            workbook.Cell(OfferteDTO.PrijsIfBtw0Cell).Value = dataObject.PrijsIfBtw0;
            workbook.Cell(OfferteDTO.PrijsIfBtw21Cell).Value = dataObject.PrijsIfBtw21;
            workbook.Cell(OfferteDTO.PrijsIfBtw6Cell).Value = dataObject.PrijsIfBtw6;
            workbook.Cell(OfferteDTO.PrijsLeftOverCell).Value = dataObject.PrijsLeftOver;
            workbook.Cell(OfferteDTO.PrijsVoorschotCell).Value = dataObject.PrijsVoorschot;
            workbook.Cell(OfferteDTO.TotaalNettoPrijsCell).Value = dataObject.TotaalNettoPrijs;
            workbook.Cell(OfferteDTO.TotaalPrijsIncBtwCell).Value = dataObject.TotaalPrijsIncBtw;
            workbook.Cell(OfferteDTO.VervalDatumCell).Value = dataObject.VervalDatum;


            using var ms = new MemoryStream();
            workbook.SaveAs(ms);
            return ms.ToArray();
        }

    }
}
