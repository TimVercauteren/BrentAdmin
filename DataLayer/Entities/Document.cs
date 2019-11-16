using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public abstract class Document : EntityBase, IDocument
    {
        public string FileName { get; set; }
        public ContactInformatie KlantenInfo { get; set; }
        public Adres KlantAdres { get; set; }
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
    }
}
