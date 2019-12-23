using DataLayer.Entities;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace DataLayer.Interfaces
{
    public interface IOfferte 
    {
        string FileName { get; set; }
        Klant Klant { get; set; }
        List<WerkLine> Werklijnen { get; set; }
        public decimal Btw { get; set; }
        public decimal TotalePrijs { get; }
        decimal GetTotalePrijs();
        decimal GetBtw();
        string OfferteNummer { get; set; }
        DateTime VervalDatum { get; set; }
        int VersieNummer { get; set; }
    }
}
