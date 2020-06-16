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
            CreateMap<Offerte, OfferteCompactDto>().ConvertUsing(new OfferteToCompactConverter());
            CreateMap<Offerte, OfferteViewModel>().ConvertUsing(new OfferteToViewModelConverter());

            CreateMap<WerkLineViewModel, WerkLine>().ConvertUsing(new WerklineModelToWerklineConverter());
            CreateMap<WerkLine, WerkLineViewModel>().ConvertUsing(new WerklineToWerklineModelConverter());

        }
    }

    public class OfferteModelToOfferteConverter : ITypeConverter<OfferteViewModel, Offerte>
    {
        public Offerte Convert(OfferteViewModel source, Offerte destination, ResolutionContext context)
        {
            return new Offerte
            {
                VervalDatum = source.VervalDatum,
                Voorschot = source.Voorschot,
                Datum = source.Datum,
                Btw = source.Btw,
                FileName = source.FileName,
                Klant = context.Mapper.Map<Klant>(source.Klant),
                OfferteNummer = source.OfferteNummer,
                VersieNummer = source.VersieNummer,
                Werklijnen = source.Werklijnen.Select(x => context.Mapper.Map<WerkLine>(x)).ToList(),
            };
        }
    }

    public class OfferteToViewModelConverter : ITypeConverter<Offerte, OfferteViewModel>
    {
        public OfferteViewModel Convert(Offerte source, OfferteViewModel destination, ResolutionContext context)
        {
            var offerteViewModel = new OfferteViewModel()
            {
                Datum = source.Datum,
                VervalDatum = source.VervalDatum,
                Voorschot = source.Voorschot,
                Werklijnen = source.Werklijnen.Select(x => context.Mapper.Map<WerkLineViewModel>(x)).ToList(),
                Btw = source.Btw,
                Klant = context.Mapper.Map<KlantViewModel>(source.Klant),
                OfferteNummer = source.OfferteNummer
            };

            return offerteViewModel;
        }
    }


    public class OfferteToCompactConverter : ITypeConverter<Offerte, OfferteCompactDto>
    {
        public OfferteCompactDto Convert(Offerte source, OfferteCompactDto destination, ResolutionContext context)
        {
            return new OfferteCompactDto
            {
                Datum = source.Datum.ToString("dd-MM-yyyy"),
                VervalDatum = source.VervalDatum.ToString("dd-MM-yyyy"),
                Id = source.Id,
                OfferteNummer = source.OfferteNummer
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
                PercentageWinst = (source.PercentageWinst / 100m)
            };
        }
    }

    public class WerklineToWerklineModelConverter : ITypeConverter<WerkLine, WerkLineViewModel>
    {
        public WerkLineViewModel Convert(WerkLine source, WerkLineViewModel destination, ResolutionContext context)
        {
            return new WerkLineViewModel
            {
                Omschrijving = source.Omschrijving?.Omschrijving,
                NettoPrijs = source.NettoPrijs,
                PercentageWinst = source.PercentageWinst
            };
        }
    }
}
