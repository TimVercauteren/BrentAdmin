using DataLayer.Entities;
using System.Collections.Generic;

namespace DataLayer.Interfaces
{
    public interface IDocument
    {
        string FileName { get; set; }
        ContactInformatie KlantenInfo { get; set; }
        Adres KlantAdres { get; set; }
        List<WerkLine> Werklijnen { get; set; }
        public decimal Btw { get; set; }
        public decimal TotalePrijs { get;}
        decimal GetTotalePrijs();
        decimal GetBtw();
    }
}
