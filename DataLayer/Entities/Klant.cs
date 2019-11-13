using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Klant : EntityBase
    {
        public Adres Adres { get; set; }
        public IList<Document> Documents { get; set; }
        public ContactInformatie Contact { get; set; }
        public string Naam { get; set; }
    }
}
