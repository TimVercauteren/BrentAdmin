using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Interfaces
{
    public interface IFactuur: IDocument
    {
        string FactuurNummer { get; set; }
        bool IsBetaald { get; set; }
        DateTime BetaaldOp { get; set; }
    }
}
