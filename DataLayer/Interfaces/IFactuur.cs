using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IFactuur
    {
        string FileName { get; set; }
        Klant Klant { get; set; }
        List<WerkLine> Werklijnen { get; set; }
        public decimal Btw { get; set; }
        public decimal TotalePrijs { get; }
        decimal GetTotalePrijs();
        decimal GetBtw();
        string FactuurNummer { get; set; }
        bool IsBetaald { get; set; }
        DateTime BetaaldOp { get; set; }
    }
}
