using DataLayer.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public class Offerte : EntityBase, IOfferte
    {
        public string OfferteNummer { get; set; }
        public DateTime VervalDatum { get; set; }
        public DateTime Datum { get; set; }
        public int VersieNummer { get; set; }
        public string FileName { get; set; }
        public Klant Klant { get; set; }
        public int KlantId { get; set; }
        public List<WerkLine> Werklijnen { get; set; }
        public decimal Btw { get; set; }

        public decimal GetTotalePrijs()
        {
            var prijs = 0m;
            this.Werklijnen.ForEach(x => prijs += x.BrutoPrijs);
            return prijs;
        }

        public decimal GetBtw()
        {
            return Btw;
        }
    }
}
