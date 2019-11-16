using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class WerkLine: EntityBase
    {
        public WerkOmschrijving Omschrijving { get; set; }
        public decimal NettoPrijs { get; set; }
        public decimal PercentageWinst { get; set; }

        [NotMapped]
        public decimal BrutoPrijs => NettoPrijs + (NettoPrijs * PercentageWinst);
    }
}
