namespace BrentWiels.Viewmodels
{
    public class WerkLineViewModel
    {
        public string Omschrijving { get; set; }
        public string IsFavoriet { get; set; }
        public decimal NettoPrijs { get; set; }
        public decimal PercentageWinst { get; set; }
        public decimal BrutoPrijs => NettoPrijs + NettoPrijs * PercentageWinst;
    }
}