using AutoMapper;
using BrentWiels.Viewmodels;
using DataLayer.Entities;

namespace BrentWiels.Mappings
{
    public class KlantenMapping : Profile
    {
        public KlantenMapping()
        {
            CreateMap<Klant, KlantViewModel>().ConvertUsing(new KlantToViewModelMapper());
            CreateMap<KlantViewModel, Klant>().ConvertUsing(new ViewModelToKlantMapper());
        }
    }

    #region Converters
    public class KlantToViewModelMapper : ITypeConverter<Klant, KlantViewModel>
    {
        public KlantViewModel Convert(Klant source, KlantViewModel destination, ResolutionContext context)
        {
            var adres = source?.Adres;
            var contact = source?.Contact;

            return new KlantViewModel()
            {
                Id = source.Id,
                Straat = adres?.StraatNaam,
                BusNummer = adres?.BusNummer,
                HuisNummer = adres?.HuisNummer,
                Gemeente = adres?.Gemeente,
                PostCode = adres?.Postcode,
                BtwNummer = contact?.BtwNummer,
                Email = contact?.Email,
                Naam = source.Naam,
                TelefoonNummer = contact?.TelefoonNummer
            };
        }
    }

    public class ViewModelToKlantMapper : ITypeConverter<KlantViewModel, Klant>
    {
        public Klant Convert(KlantViewModel source, Klant destination, ResolutionContext context)
        {
            var adres = new Adres()
            {
                BusNummer = source.BusNummer,
                HuisNummer = source.HuisNummer,
                Gemeente = source.Gemeente,
                StraatNaam = source.Straat,
                Postcode = source.PostCode
            };

            var contact = new ContactInformatie()
            {
                BtwNummer = source.BtwNummer,
                Email = source.Email,
                TelefoonNummer = source.TelefoonNummer
            };

            return new Klant()
            {
                Adres = adres,
                Naam = source.Naam,
                Contact = contact,
                Id = source.Id
            };
        }
    }
    #endregion
}
