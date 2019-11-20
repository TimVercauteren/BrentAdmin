using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DocumentFormat.OpenXml.Spreadsheet;
using Documents.DTO;
using Documents.Interfaces;

namespace Documents
{
    public class OfferteGenerator : IOfferteGenerator
    {
        public OfferteGenerator()
        {

        }

        public static Workbook GetOfferteTemplate()
        {
            const string fullpath = "Templates\\BrentOfferteTemplate.xlsx";
            var offerte = new Workbook(fullpath);
            return offerte;
        }

        public void FillTemplateWithOfferteData(OfferteDTO dataObject)
        {
            var template = GetOfferteTemplate();



        }

    }
}
