using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Adres : EntityBase
    {
        public string StraatNaam { get; set; }
        public string HuisNummer { get; set; }
        public string BusNummer { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }
    }
}
