using System;
using System.Collections.Generic;
using System.Text;
using DocumentFormat.OpenXml.CustomProperties;

namespace Documents.DTO
{
    public class OfferteDTO : DocumentDto
    {
        public string VervalDatum { get; set; }
        public string PrijsVoorschot { get; set; }
        public string PrijsLeftOver { get; set; }
    }
}
