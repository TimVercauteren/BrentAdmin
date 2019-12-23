using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DataLayer.Interfaces;

namespace DataLayer.Entities
{
    public class Factuur : EntityBase, IFactuur
    {
        public string FileName { get; set; }
        public Klant Klant { get; set; }
        public List<WerkLine> Werklijnen { get; set; }
        public decimal Btw { get; set; }

        [NotMapped]
        public decimal TotalePrijs {
            get {
                var prijs = 0m;
                this.Werklijnen.ForEach(x => prijs += x.BrutoPrijs);
                return prijs;
            }
        }

        public decimal GetBtw()
        {
            return TotalePrijs * Btw;
        }

        public decimal GetTotalePrijs()
        {
            return TotalePrijs + TotalePrijs * Btw;
        }
        public string FactuurNummer { get; set; }
        public bool IsBetaald { get; set; }
        public DateTime BetaaldOp { get; set; }
    }
}
