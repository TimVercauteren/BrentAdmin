using System.Linq;
using AutoMapper;
using BrentWiels.Viewmodels;
using DataLayer.Entities;

namespace BrentWiels.Mappings
{
    public class OfferteMappings : Profile
    {
        public OfferteMappings()
        {
            CreateMap<OfferteViewModel, Offerte>().ConvertUsing(new OfferteModelToOfferteConverter());

            CreateMap<WerkLineViewModel, WerkLine>().ConvertUsing(new WerklineModelToWerklineConverter());
        }
    }

    public class OfferteModelToOfferteConverter : ITypeConverter<OfferteViewModel, Offerte>
    {
        public Offerte Convert(OfferteViewModel source, Offerte destination, ResolutionContext context)
        {
            return new Offerte
            {
                VervalDatum = source.VervalDatum,
                Btw = source.Btw,
                FileName = source.FileName,
                Klant = context.Mapper.Map<Klant>(source.Klant),
                OfferteNummer = source.OfferteNummer,
                VersieNummer = source.VersieNummer,
                Werklijnen = source.Werklijnen.Select(x => context.Mapper.Map<WerkLine>(x)).ToList(),
            };
        }
    }

    public class WerklineModelToWerklineConverter : ITypeConverter<WerkLineViewModel, WerkLine>
    {
        public WerkLine Convert(WerkLineViewModel source, WerkLine destination, ResolutionContext context)
        {
            return new WerkLine
            {
                NettoPrijs = source.NettoPrijs,
                Omschrijving = new WerkOmschrijving()
                {
                    Omschrijving = source.Omschrijving,
                    IsFavoriet = false
                },
                PercentageWinst = source.PercentageWinst
            };
        }
    }
}
