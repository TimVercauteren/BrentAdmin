using System.IO;
using ClosedXML.Excel;
using Documents.DTO;
using Documents.Interfaces;
using Documents.Properties;

namespace Documents
{
    public class OfferteGenerator : IGenerator
    {
        public static XLWorkbook GetOfferteTemplate()
        {
            var exceltemplate = Resources.BrentOfferteTemplate;
            var ms = new MemoryStream(exceltemplate);
            var offerte = new XLWorkbook(ms);
            return offerte;
        }

        public byte[] FillTemplateWithFactuurData(FactuurDto dataObject)
        {
            var workbook = GetOfferteTemplate();

            try
            {
                FillFactuurWorkbook(dataObject, workbook);

                using (var memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);
                    return memoryStream.ToArray();
                }
            }
            finally
            {
                if (workbook != null) workbook.Dispose();
            }
        }

        public byte[] FillTemplateWithOfferteData(OfferteDTO dataObject)
        {
            var workbook = GetOfferteTemplate();

            try
            {
                FillOfferteWorkbook(dataObject, workbook);

                using (var memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);
                    return memoryStream.ToArray();
                }
            }
            finally
            {
                if (workbook != null) workbook.Dispose();
            }
        }

        private static void FillOfferteWorkbook(DocumentDto dataObject, XLWorkbook workbook)
        {
            if (!workbook.TryGetWorksheet("offerte", out var sheet))
            {
                throw new System.Exception("Cannot find Worksheet Offerte");
            }
            sheet.Cell(DocumentDto.DatumCell).Value = dataObject.Datum;


            sheet.Cell(DocumentDto.TypeCell).Value = "Offerte";
            sheet.Cell(DocumentDto.ItemFactuurCell).Value = "";
            sheet.Cell(DocumentDto.ItemFactuurPrijsCell).Value = "";

            sheet.Cell(DocumentDto.Items1Cell).Value = dataObject.Item1;
            sheet.Cell(DocumentDto.Items2Cell).Value = dataObject.Item2;
            sheet.Cell(DocumentDto.Items3Cell).Value = dataObject.Item3;
            sheet.Cell(DocumentDto.Items4Cell).Value = dataObject.Item4;
            sheet.Cell(DocumentDto.Items5Cell).Value = dataObject.Item5;
            sheet.Cell(DocumentDto.Items6Cell).Value = dataObject.Item6;

            sheet.Cell(DocumentDto.Items1PrijsCell).Value = dataObject.Item1Prijs;
            sheet.Cell(DocumentDto.Items2PrijsCell).Value = dataObject.Item2Prijs;
            sheet.Cell(DocumentDto.Items3PrijsCell).Value = dataObject.Item3Prijs;
            sheet.Cell(DocumentDto.Items4PrijsCell).Value = dataObject.Item4Prijs;
            sheet.Cell(DocumentDto.Items5PrijsCell).Value = dataObject.Item5Prijs;
            sheet.Cell(DocumentDto.Items6PrijsCell).Value = dataObject.Item6Prijs;


            sheet.Cell(DocumentDto.KlantBtwCell).Value = dataObject.KlantBtw;
            sheet.Cell(DocumentDto.KlantEmailCell).Value = dataObject.KlantEmail;
            sheet.Cell(DocumentDto.KlantNaamCell).Value = dataObject.KlantNaam;
            sheet.Cell(DocumentDto.KlantPostcodeGemeenteCell).Value = dataObject.KlantPostcodeGemeente;
            sheet.Cell(DocumentDto.KlantRefCell).Value = dataObject.KlantRef;
            sheet.Cell(DocumentDto.KlantStraatNummerCell).Value = dataObject.KlantStraatNummer;
            sheet.Cell(DocumentDto.KlantTelefoonCell).Value = dataObject.KlantTelefoon;
            sheet.Cell(DocumentDto.OfferteNummerCell).Value = $"#{dataObject.OfferteNummer}";
            sheet.Cell(DocumentDto.PrijsIfBtw0Cell).Value = dataObject.PrijsIfBtw0;
            sheet.Cell(DocumentDto.PrijsIfBtw21Cell).Value = dataObject.PrijsIfBtw21;
            sheet.Cell(DocumentDto.PrijsIfBtw6Cell).Value = dataObject.PrijsIfBtw6;
            sheet.Cell(DocumentDto.PrijsLeftOverCell).Value = dataObject.PrijsLeftOver;
            sheet.Cell(DocumentDto.PrijsVoorschotCell).Value = dataObject.PrijsVoorschot;
            sheet.Cell(DocumentDto.TotaalNettoPrijsCell).Value = dataObject.TotaalNettoPrijs;
            sheet.Cell(DocumentDto.TotaalPrijsIncBtwCell).Value = dataObject.TotaalPrijsIncBtw;
            sheet.Cell(DocumentDto.VervalDatumCell).Value = dataObject.VervalDatum;
        }

        private static void FillFactuurWorkbook(DocumentDto dataObject, XLWorkbook workbook)
        {
            if (!workbook.TryGetWorksheet("offerte", out var sheet))
            {
                throw new System.Exception("Cannot find Worksheet Offerte");
            }

            sheet.Cell(DocumentDto.DatumCell).Value = dataObject.Datum;
            sheet.Cell(DocumentDto.TypeCell).Value = "Factuur";
            sheet.Cell(DocumentDto.ItemFactuurCell).Value = dataObject.ItemFactuur;
            sheet.Cell(DocumentDto.ItemFactuurPrijsCell).Value = dataObject.ItemFactuurPrijs;

            sheet.Cell(DocumentDto.Items1Cell).Value = dataObject.Item1;
            sheet.Cell(DocumentDto.Items2Cell).Value = dataObject.Item2;
            sheet.Cell(DocumentDto.Items3Cell).Value = dataObject.Item3;
            sheet.Cell(DocumentDto.Items4Cell).Value = dataObject.Item4;
            sheet.Cell(DocumentDto.Items5Cell).Value = dataObject.Item5;
            sheet.Cell(DocumentDto.Items6Cell).Value = dataObject.Item6;

            sheet.Cell(DocumentDto.Items1PrijsCell).Value = dataObject.Item1Prijs;
            sheet.Cell(DocumentDto.Items2PrijsCell).Value = dataObject.Item2Prijs;
            sheet.Cell(DocumentDto.Items3PrijsCell).Value = dataObject.Item3Prijs;
            sheet.Cell(DocumentDto.Items4PrijsCell).Value = dataObject.Item4Prijs;
            sheet.Cell(DocumentDto.Items5PrijsCell).Value = dataObject.Item5Prijs;
            sheet.Cell(DocumentDto.Items6PrijsCell).Value = dataObject.Item6Prijs;

            sheet.Cell(DocumentDto.KlantBtwCell).Value = dataObject.KlantBtw;
            sheet.Cell(DocumentDto.KlantEmailCell).Value = dataObject.KlantEmail;
            sheet.Cell(DocumentDto.KlantNaamCell).Value = dataObject.KlantNaam;
            sheet.Cell(DocumentDto.KlantPostcodeGemeenteCell).Value = dataObject.KlantPostcodeGemeente;
            sheet.Cell(DocumentDto.KlantRefCell).Value = dataObject.KlantRef;
            sheet.Cell(DocumentDto.KlantStraatNummerCell).Value = dataObject.KlantStraatNummer;
            sheet.Cell(DocumentDto.KlantTelefoonCell).Value = dataObject.KlantTelefoon;
            sheet.Cell(DocumentDto.OfferteNummerCell).Value = $"#{dataObject.FactuurNummer}";
            sheet.Cell(DocumentDto.PrijsIfBtw0Cell).Value = dataObject.PrijsIfBtw0;
            sheet.Cell(DocumentDto.PrijsIfBtw21Cell).Value = dataObject.PrijsIfBtw21;
            sheet.Cell(DocumentDto.PrijsIfBtw6Cell).Value = dataObject.PrijsIfBtw6;
            sheet.Cell(DocumentDto.PrijsLeftOverCell).Value = "";
            sheet.Cell(DocumentDto.PrijsVoorschotCell).Value = "";
            sheet.Cell(DocumentDto.TotaalNettoPrijsCell).Value = dataObject.TotaalNettoPrijs;
            sheet.Cell(DocumentDto.TotaalPrijsIncBtwCell).Value = dataObject.TotaalPrijsIncBtw;
            sheet.Cell(DocumentDto.VervalDatumCell).Value = dataObject.VervalDatum;

            // remove non factuur stuff
            sheet.Range("A38:D65").Clear();
            sheet.Cell("C5").Clear();
            sheet.Cell("D5").Clear();

            var cell = sheet.Cell("C6");
            cell.Value = "FACTUURNUMMER";
            cell.SetDataType(XLDataType.Text);
            cell.Style.Font.Bold = true;
            cell.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
            
        }
    }
}
