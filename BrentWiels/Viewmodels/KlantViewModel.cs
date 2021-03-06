﻿namespace BrentWiels.Viewmodels
{
    public class KlantViewModel : ModelBase
    {
        public string Naam { get; set; }
        public string Straat { get; set; }
        public string HuisNummer { get; set; }
        public string BusNummer { get; set; }
        public string PostCode { get; set; }
        public string Gemeente { get; set; }
        public string TelefoonNummer { get; set; }
        public string Email { get; set; }
        public string BtwNummer { get; set; }
        public string KlantenRef { get; set; }
        public string FullAdress {
            get {
                return string.Format($"{Straat} {HuisNummer}{BusNummer} {PostCode} {Gemeente}");
            }
        }
    }
}
