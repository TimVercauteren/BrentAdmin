using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Klant : EntityBase
    {
        public Adres Adres { get; set; }
        public IList<Factuur> Facturen { get; set; }
        public IList<Offerte> Offertes { get; set; }
        public ContactInformatie Contact { get; set; }
        public string Naam { get; set; }
        public bool IsDeleted { get; set; }
    }
}
