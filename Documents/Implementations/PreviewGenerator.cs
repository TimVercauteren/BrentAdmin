using Documents.DTO;
using Documents.Interfaces;
using System;
using System.IO;
using System.Reflection;

namespace Documents.Implementations
{
    public class PreviewGenerator : DocumentGenerator, IPreviewGenerator
    {

        static readonly string Offerte = "Offerte";

        public override string FillDocumentTemplate(DocumentDto dataObject)
        {
            var dto = dataObject as OfferteDTO;

            var template = base.FillDocumentTemplate(dataObject);

            template = template.Replace(Ost.Type, Offerte);
            template = template.Replace(Ost.VervalDatum, dto.VervalDatum);
            template = template.Replace(Ost.PrijsVoorschot, dto.PrijsVoorschot);
            template = template.Replace(Ost.PrijsLeftOver, dto.PrijsLeftOver);

            template = template.Replace(Ost.ItemFactuur, "");
            template = template.Replace(Ost.ItemFactuurPrijs, "");

            return template;
        }

        public byte[] GetPdfBytes(OfferteDTO offerteDto)
        {
            var html = this.FillDocumentTemplate(offerteDto);

            var renderer = new IronPdf.HtmlToPdf();

            var assembly = Assembly.GetExecutingAssembly().Location;

            var filePath = Path.GetDirectoryName(assembly);

            return renderer.RenderHtmlAsPdf(html, Path.Combine(filePath, "Templates")).Stream.ToArray();
        }
    }
}
