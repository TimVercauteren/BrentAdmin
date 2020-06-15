using Documents.DTO;
using Documents.Interfaces;
using System;
using System.IO;

namespace Documents.Implementations
{
    public class OfferteGenerator : DocumentGenerator, IOfferteGenerator
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
    }
}
