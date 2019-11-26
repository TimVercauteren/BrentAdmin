using AutoMapper;
using BrentWiels.Data.Interfaces;
using BrentWiels.Viewmodels;
using DataLayer.Interfaces;
using DataLayer.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrentWiels.Data
{
    public class OfferteDataService : IOfferteDataService
    {
        private readonly IOfferteRepository _offerteRepo;
        private readonly IKlantenRepository _klantenRepo;
        private readonly IMapper _mapper;

        public OfferteDataService(IOfferteRepository offerteRepo, IKlantenRepository klantenRepo, IMapper mapper)
        {
            _offerteRepo = offerteRepo;
            _klantenRepo = klantenRepo;
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
                VersieNummer = klantNummer == null ? 1 : klantNummer.Value
            };
        }
    }
}
