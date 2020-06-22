using System.Linq;
using AutoMapper;
using BrentWiels.Viewmodels;
using DataLayer.Entities;

namespace BrentWiels.Mappings
{
    public class FactuurMappings : Profile
    {
        public FactuurMappings()
        {
            CreateMap<Factuur, FactuurCompactDto>().ConvertUsing(new FactuurToCompactDtoConverter());

        }
    }

    public class FactuurToCompactDtoConverter : ITypeConverter<Factuur, FactuurCompactDto>
    {
        public FactuurCompactDto Convert(Factuur source, FactuurCompactDto destination, ResolutionContext context)
        {
            return new FactuurCompactDto
            {
                Datum = source.Offerte.Datum.ToString("dd-MM-yyyy"),
                Id = source.Id,
                IsDownloaded = source.IsDownloaded,
                FactuurNummer = source.FactuurNummer,
                OfferteNummer = source.Offerte.OfferteNummer
            };
        }
    }
}
