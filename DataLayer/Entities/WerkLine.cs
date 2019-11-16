using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public class WerkLine
    {
        public string Description { get; set; }
        public decimal NettoPrijs { get; set; }
        public decimal PercentageWinst { get; set; }

        [NotMapped]
        public decimal BrutoPrijs => NettoPrijs + (NettoPrijs * PercentageWinst);
    }
}
