﻿using System;

namespace DataLayer.Entities
{
    public class Factuur : EntityBase
    {
        public Offerte Offerte { get; set; }
        public int OfferteId { get; set; }
        public WerkLine ExtraWerklijn { get; set; }
        public string FactuurNummer { get; set; }
        public bool IsDownloaded { get; set; }
        public DateTime FactuurDatum { get; set; }
    }
}
