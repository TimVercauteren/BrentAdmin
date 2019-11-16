using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Offerte : Document, IOfferte
    {
        public string OfferteNummer { get; set; }
        public DateTime VervalDatum { get; set; }
        public int VersieNummer { get; set; }
    }
}
