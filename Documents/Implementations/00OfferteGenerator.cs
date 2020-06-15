//using System.IO;
//using ClosedXML.Excel;
//using Documents.DTO;
//using Documents.Interfaces;
//using Documents.Properties;

//namespace Documents
//{
//    public class OfferteGenerator : IOfferteGenerator
//    {
//        public static XLWorkbook GetOfferteTemplate()
//        {
//            var exceltemplate = Resources.BrentOfferteTemplate;
//            var ms = new MemoryStream(exceltemplate);
//            var offerte = new XLWorkbook(ms);
//            return offerte;
//        }

//        public byte[] FillTemplateWithOfferteData(OfferteDTO dataObject)
//        {
//            var workbook = GetOfferteTemplate();

//            try
//            {
//                if (!workbook.TryGetWorksheet("offerte", out var sheet))
//                {
//                    throw new System.Exception("Cannot find Worksheet Offerte");
//                }
//                sheet.Cell(OfferteDTO.DatumCell).Value = dataObject.Datum;

//                sheet.Cell(OfferteDTO.Items1Cell).Value = dataObject.Item1;
//                sheet.Cell(OfferteDTO.Items2Cell).Value = dataObject.Item2;
//                sheet.Cell(OfferteDTO.Items3Cell).Value = dataObject.Item3;
//                sheet.Cell(OfferteDTO.Items4Cell).Value = dataObject.Item4;
//                sheet.Cell(OfferteDTO.Items5Cell).Value = dataObject.Item5;
//                sheet.Cell(OfferteDTO.Items6Cell).Value = dataObject.Item6;

//                sheet.Cell(OfferteDTO.KlantBtwCell).Value = dataObject.KlantBtw;
//                sheet.Cell(OfferteDTO.KlantEmailCell).Value = dataObject.KlantEmail;
//                sheet.Cell(OfferteDTO.KlantNaamCell).Value = dataObject.KlantNaam;
//                sheet.Cell(OfferteDTO.KlantPostcodeGemeenteCell).Value = dataObject.KlantPostcodeGemeente;
//                sheet.Cell(OfferteDTO.KlantRefCell).Value = dataObject.KlantRef;
//                sheet.Cell(OfferteDTO.KlantStraatNummerCell).Value = dataObject.KlantStraatNummer;
//                sheet.Cell(OfferteDTO.KlantTelefoonCell).Value = dataObject.KlantTelefoon;
//                sheet.Cell(OfferteDTO.OfferteNummerCell).Value = $"#{dataObject.OfferteNummer}";
//                sheet.Cell(OfferteDTO.PrijsIfBtw0Cell).Value = dataObject.PrijsIfBtw0;
//                sheet.Cell(OfferteDTO.PrijsIfBtw21Cell).Value = dataObject.PrijsIfBtw21;
//                sheet.Cell(OfferteDTO.PrijsIfBtw6Cell).Value = dataObject.PrijsIfBtw6;
//                sheet.Cell(OfferteDTO.PrijsLeftOverCell).Value = dataObject.PrijsLeftOver;
//                sheet.Cell(OfferteDTO.PrijsVoorschotCell).Value = dataObject.PrijsVoorschot;
//                sheet.Cell(OfferteDTO.TotaalNettoPrijsCell).Value = dataObject.TotaalNettoPrijs;
//                sheet.Cell(OfferteDTO.TotaalPrijsIncBtwCell).Value = dataObject.TotaalPrijsIncBtw;
//                sheet.Cell(OfferteDTO.VervalDatumCell).Value = dataObject.VervalDatum;

//                using (var memoryStream = new MemoryStream())
//                {
//                    workbook.SaveAs(memoryStream);
//                    return memoryStream.ToArray();
//                }
//            }
//            finally
//            {
//                if (workbook != null) workbook.Dispose();
//            }
//        }
//    }
//}
