using DataLayer.Entities;
using DataLayer.Interfaces;
using System;

namespace DataLayer.Interfaces
{
    public interface IOfferte : IDocument
    {
        string OfferteNummer { get; set; }
        DateTime VervalDatum { get; set; }
        int VersieNummer { get; set; }
    }
}
