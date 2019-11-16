using System;
using DataLayer.Interfaces;

namespace DataLayer.Entities
{
    public class Factuur : Document, IFactuur
    {
        public string FactuurNummer { get; set; }
        public bool IsBetaald { get; set; }
        public DateTime BetaaldOp { get; set; }
    }
}
