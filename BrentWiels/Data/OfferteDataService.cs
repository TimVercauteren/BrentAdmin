using AutoMapper;
using BrentWiels.Data.Interfaces;
using BrentWiels.Viewmodels;
using DataLayer.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Entities;
using Documents.Interfaces;
using Documents.DTO;

namespace BrentWiels.Data
{
    public class OfferteDataService : IOfferteDataService
    {
        private readonly IOfferteRepository _offerteRepo;
        private readonly IKlantenRepository _klantenRepo;
        private readonly IOfferteGenerator _offerteGenerator;
        private readonly IMapper _mapper;

        public OfferteDataService(IOfferteRepository offerteRepo, IKlantenRepository klantenRepo, IMapper mapper, IOfferteGenerator offerteGenerator)
        {
            _offerteRepo = offerteRepo;
            _klantenRepo = klantenRepo;
            _offerteGenerator = offerteGenerator;
            _mapper = mapper;

        }

        public async Task<OfferteViewModel> GetNewOfferteForCustomer(int KlantId)
        {
            var nummer = await _offerteRepo.GetNextNummer();
            var klant = await _klantenRepo.Get(KlantId);
            var klantViewModel = _mapper.Map<KlantViewModel>(klant);
            var klantNummer = (await _klantenRepo.GetPreviousOffertes(KlantId))?.Count();
            var fileName = klant?.Naam ?? "";
            if (klantNummer.HasValue && klantNummer.Value != 0)
            {
                fileName += klantNummer.Value;
            }

            return new OfferteViewModel()
            {
                OfferteNummer = nummer,
                Klant = klantViewModel,
                FileName = fileName,
                Datum = DateTime.Today,
                VervalDatum = DateTime.Today.AddDays(10).Date,
                Werklijnen = new List<WerkLineViewModel>(),
                VersieNummer = klantNummer ?? 1
            };
        }

        public async Task AddOfferteForCustomer(OfferteViewModel offerte)
        {
            offerte.Datum = DateTime.Today.Date;
            var entity = _mapper.Map<Offerte>(offerte);
            await _offerteRepo.Add(entity);
        }

        public async Task<byte[]> GetOfferteBytes(int offerteId)
        {
            var offerte = await _offerteRepo.GetFullOfferte(offerteId);

            var offerteDto = ConvertToTemplate(offerte);

            return _offerteGenerator.GetPdfBytes(offerteDto);
        }

        public async Task<string> GetOfferteHtml(int offerteId)
        {
            var offerte = await _offerteRepo.GetFullOfferte(offerteId);

            var offerteDto = ConvertToTemplate(offerte);

            var template = _offerteGenerator.FillDocumentTemplate(offerteDto);

            return template;
        }

        private OfferteDTO ConvertToTemplate(Offerte retVal)
        {
            var klantNummer = string.Format($"{retVal?.Klant?.Adres?.StraatNaam} {retVal?.Klant?.Adres?.HuisNummer} {retVal?.Klant?.Adres?.BusNummer}");

            var dto = new OfferteDTO
            {
                Datum = retVal.Datum.Date.ToString("dd-MM-yyyy"),
                VervalDatum = retVal.VervalDatum.Date.ToString("dd-MM-yyyy"),
                KlantBtw = retVal?.Klant?.Contact?.BtwNummer ?? "",
                KlantEmail = retVal?.Klant?.Contact?.Email,
                KlantNaam = retVal?.Klant?.Naam,
                KlantPostcodeGemeente = $"{retVal?.Klant?.Adres?.Postcode} {retVal?.Klant?.Adres?.Gemeente}",
                KlantRef = "",
                KlantStraatNummer = klantNummer.Trim(),
                KlantTelefoon = retVal?.Klant?.Contact?.TelefoonNummer,
                OfferteNummer = retVal.OfferteNummer,
                PrijsIfBtw0 = "",
                PrijsIfBtw21 = "",
                PrijsIfBtw6 = "",
                PrijsLeftOver = "",
                PrijsVoorschot = "",
                TotaalNettoPrijs = "",
                TotaalPrijsIncBtw = "",
            };

            SetWorkItems(dto, retVal);
            SetPrices(dto, retVal);

            dto.Item1 = dto.WorkItems[0]?.Omschrijving?.Omschrijving;
            dto.Item2 = dto.WorkItems[1]?.Omschrijving?.Omschrijving;
            dto.Item3 = dto.WorkItems[2]?.Omschrijving?.Omschrijving;
            dto.Item4 = dto.WorkItems[3]?.Omschrijving?.Omschrijving;
            dto.Item5 = dto.WorkItems[4]?.Omschrijving?.Omschrijving;
            dto.Item6 = dto.WorkItems[5]?.Omschrijving?.Omschrijving;

            dto.Item1Prijs = dto.WorkItems[0]?.BrutoPrijs.ToString("#.##");
            dto.Item2Prijs = dto.WorkItems[1]?.BrutoPrijs.ToString("#.##");
            dto.Item3Prijs = dto.WorkItems[2]?.BrutoPrijs.ToString("#.##");
            dto.Item4Prijs = dto.WorkItems[3]?.BrutoPrijs.ToString("#.##");
            dto.Item5Prijs = dto.WorkItems[4]?.BrutoPrijs.ToString("#.##");
            dto.Item6Prijs = dto.WorkItems[5]?.BrutoPrijs.ToString("#.##");


            return dto;
        }

        private void SetPrices(OfferteDTO dto, Offerte retVal)
        {
            var totalePrijs = retVal.GetTotalePrijs();
            var btw = retVal.GetBtw();

            dto.TotaalNettoPrijs = totalePrijs.ToString("#.##");

            if (btw == 0.00m)
            {
                dto.PrijsIfBtw0 = "0";
                dto.TotaalPrijsIncBtw = totalePrijs.ToString("#.##");
            }
            if (btw == 0.06m)
            {
                var tax = totalePrijs * 0.06m;
                dto.PrijsIfBtw6 = tax.ToString("#.##");
                dto.TotaalPrijsIncBtw = (totalePrijs + tax).ToString("#.##");
            }
            if (btw == 0.21m)
            {
                var tax = totalePrijs * 0.21m;
                dto.PrijsIfBtw21 = tax.ToString("#.##");
                dto.TotaalPrijsIncBtw = (totalePrijs + tax).ToString("#.##");
            }

            dto.PrijsVoorschot = (decimal.Parse(dto.TotaalPrijsIncBtw) / 2).ToString("#.##");
            dto.PrijsLeftOver = dto.PrijsVoorschot;
        }

        private void SetWorkItems(OfferteDTO dto, Offerte retVal)
        {
            var max = retVal.Werklijnen.Count();
            dto.WorkItems = new WerkLine[6];
            for (int i = 0; i < 6; i++)
            {
                if (i < max)
                {
                    dto.WorkItems[i] = retVal.Werklijnen[i];
                }
                else
                {
                    dto.WorkItems[i] = null;
                }
            }
        }

        public async Task<OfferteViewModel> GetOffertePreview(int offerteId)
        {
            var fullOfferte = await _offerteRepo.GetFullOfferte(offerteId);

            return _mapper.Map<OfferteViewModel>(fullOfferte);
        }

        public async Task DeleteOfferte(int offerteId)
        {
            await _offerteRepo.Delete(offerteId);
        }
    }
}
