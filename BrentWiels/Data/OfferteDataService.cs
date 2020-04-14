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
                VervalDatum = DateTime.Today.AddDays(10).Date,
                Werklijnen = new List<WerkLineViewModel>(),
                VersieNummer = klantNummer ?? 1
            };
        }

        public async Task<byte[]> AddOfferteForCustomer(OfferteViewModel offerte)
        {
            var entity = _mapper.Map<Offerte>(offerte);
            var retVal = await _offerteRepo.Add(entity);

            var offerteTemplate = ConvertToTemplate(retVal);

            return _offerteGenerator.FillTemplateWithOfferteData(offerteTemplate);
        }



        private OfferteDTO ConvertToTemplate(Offerte retVal)
        {
            var dto = new OfferteDTO
            {
                Datum = DateTime.Now.Date.ToString("dd-MM-yyyy"),
                VervalDatum = retVal.VervalDatum.Date.ToString("dd-MM-yyyy"),
                KlantBtw = retVal?.Klant?.Contact?.BtwNummer,
                KlantEmail = retVal?.Klant?.Contact?.Email,
                KlantNaam = retVal?.Klant?.Naam,
                KlantPostcodeGemeente = retVal?.Klant?.Adres?.Postcode,
                KlantRef = "",
                KlantStraatNummer = retVal?.Klant?.Adres?.StraatNaam,
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

            dto.Item1 = dto.WorkItems[0];
            dto.Item2 = dto.WorkItems[1];
            dto.Item3 = dto.WorkItems[2];
            dto.Item4 = dto.WorkItems[3];
            dto.Item5 = dto.WorkItems[4];
            dto.Item6 = dto.WorkItems[5];


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
                dto.PrijsIfBtw21 =  tax.ToString("#.##");
                dto.TotaalPrijsIncBtw = (totalePrijs + tax).ToString("#.##");
            }

            dto.PrijsVoorschot = (decimal.Parse(dto.TotaalPrijsIncBtw) / 2).ToString("#.##");
            dto.PrijsLeftOver = dto.PrijsVoorschot;
        }

        private void SetWorkItems(OfferteDTO dto, Offerte retVal)
        {
            var max = retVal.Werklijnen.Count();
            dto.WorkItems = new string[6];
            for (int i = 0; i < 6; i++)
            {
                if (i < max)
                {
                    dto.WorkItems[i] = retVal.Werklijnen[i].Omschrijving.Omschrijving;
                }
                else
                {
                    dto.WorkItems[i] = "";
                }
            }
        }
    }
}
