using AutoMapper;
using BrentWiels.Data.Interfaces;
using BrentWiels.Viewmodels;
using DataLayer.Entities;
using DataLayer.Interfaces.Repositories;
using DataLayer.Repositories;
using DocumentFormat.OpenXml.Bibliography;
using Documents.DTO;
using Documents.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace BrentWiels.Data
{

    public class FactuurDataService : IFactuurService
    {
        private readonly IOfferteRepository _offerteRepo;
        private readonly IGenerator _generator;
        private readonly IFactuurRepository _factuurRepo;
        private readonly IMapper _mapper;

        public FactuurDataService(IOfferteRepository offerteRepo, IGenerator generator, IFactuurRepository factuurRepository, IMapper mapper)
        {
            _offerteRepo = offerteRepo;
            _generator = generator;
            _factuurRepo = factuurRepository;
            _mapper = mapper;
        }

        public async Task AddFactuur(int offerteId, WerkLineViewModel extraWerkline)
        {
            var factuur = new Factuur
            {
                OfferteId = offerteId,
                ExtraWerklijn = _mapper.Map<WerkLine>(extraWerkline)
            };

            string factuurNummer = await _factuurRepo.GetNextFactuurNumber();
            factuur.FactuurNummer = factuurNummer;

            await _factuurRepo.Add(factuur);

        }

        public async Task<byte[]> GetFactuurBytes(int factuurId)
        {
            var factuur = await _factuurRepo.GetFullFactuur(factuurId);

            var offerteDto = ConvertToTemplate(factuur);

            return _generator.FillTemplateWithFactuurData(offerteDto);
        }

        private FactuurDto ConvertToTemplate(Factuur retVal)
        {
            var offerte = retVal.Offerte;

            var klantNummer = string.Format($"{offerte?.Klant?.Adres?.StraatNaam} {offerte?.Klant?.Adres?.HuisNummer} {offerte?.Klant?.Adres?.BusNummer}");

            var dto = new FactuurDto
            {
                Datum = offerte.Datum.Date.ToString("dd-MM-yyyy"),
                KlantBtw = offerte?.Klant?.Contact?.BtwNummer ?? "",
                KlantEmail = offerte?.Klant?.Contact?.Email,
                KlantNaam = offerte?.Klant?.Naam,
                KlantPostcodeGemeente = $"{offerte?.Klant?.Adres?.Postcode} {offerte?.Klant?.Adres?.Gemeente}",
                KlantRef = offerte?.Klant?.KlantenRef.ToString("00000"),
                KlantStraatNummer = klantNummer.Trim(),
                KlantTelefoon = offerte?.Klant?.Contact?.TelefoonNummer,
                FactuurNummer = retVal.FactuurNummer,
                PrijsIfBtw0 = "",
                PrijsIfBtw21 = "",
                PrijsIfBtw6 = "",
                PrijsLeftOver = "",
                PrijsVoorschot = "",
                TotaalNettoPrijs = "",
                TotaalPrijsIncBtw = "",
                ItemFactuur = retVal?.ExtraWerklijn?.Omschrijving?.Omschrijving,
                ItemFactuurPrijs = retVal?.ExtraWerklijn?.BrutoPrijs.ToString("#.00")
            };

            SetWorkItems(dto, retVal);
            SetPrices(dto, retVal);

            dto.Item1 = dto.WorkItems[0]?.Omschrijving?.Omschrijving;
            dto.Item2 = dto.WorkItems[1]?.Omschrijving?.Omschrijving;
            dto.Item3 = dto.WorkItems[2]?.Omschrijving?.Omschrijving;
            dto.Item4 = dto.WorkItems[3]?.Omschrijving?.Omschrijving;
            dto.Item5 = dto.WorkItems[4]?.Omschrijving?.Omschrijving;
            dto.Item6 = dto.WorkItems[5]?.Omschrijving?.Omschrijving;

            dto.Item1Prijs = dto.WorkItems[0]?.BrutoPrijs.ToString("#.00");
            dto.Item2Prijs = dto.WorkItems[1]?.BrutoPrijs.ToString("#.00");
            dto.Item3Prijs = dto.WorkItems[2]?.BrutoPrijs.ToString("#.00");
            dto.Item4Prijs = dto.WorkItems[3]?.BrutoPrijs.ToString("#.00");
            dto.Item5Prijs = dto.WorkItems[4]?.BrutoPrijs.ToString("#.00");
            dto.Item6Prijs = dto.WorkItems[5]?.BrutoPrijs.ToString("#.00");

            return dto;
        }

        private void SetPrices(FactuurDto dto, Factuur retVal)
        {
            var offerte = retVal?.Offerte;

            var totalePrijs = offerte.GetTotalePrijs() + retVal.ExtraWerklijn.BrutoPrijs;
            var btw = offerte.GetBtw();

            dto.TotaalNettoPrijs = totalePrijs.ToString("#.00");

            if (btw == 0.00m)
            {
                dto.PrijsIfBtw0 = "-";
                dto.TotaalPrijsIncBtw = totalePrijs.ToString("#.00");
            }
            if (btw == 0.06m)
            {
                var tax = totalePrijs * 0.06m;
                dto.PrijsIfBtw6 = tax.ToString("#.00");
                dto.TotaalPrijsIncBtw = (totalePrijs + tax).ToString("#.00");
            }
            if (btw == 0.21m)
            {
                var tax = totalePrijs * 0.21m;
                dto.PrijsIfBtw21 = tax.ToString("#.00");
                dto.TotaalPrijsIncBtw = (totalePrijs + tax).ToString("#.00");
            }
        }

        private void SetWorkItems(DocumentDto dto, Factuur retVal)
        {
            var max = retVal.Offerte.Werklijnen.Count();
            dto.WorkItems = new WerkLine[6];
            for (int i = 0; i < 6; i++)
            {
                if (i < max)
                {
                    dto.WorkItems[i] = retVal.Offerte.Werklijnen[i];
                }
                else
                {
                    dto.WorkItems[i] = null;
                }
            }
        }

        public async Task DeleteOfferte(int offerteId)
        {
            await _offerteRepo.Delete(offerteId);
        }
    }
}
