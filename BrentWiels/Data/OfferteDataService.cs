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
using Documents.Mock;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace BrentWiels.Data
{
    public class OfferteDataService : IOfferteDataService
    {
        private readonly IOfferteRepository _offerteRepo;
        private readonly IKlantenRepository _klantenRepo;
        private readonly IOfferteGenerator _offerteGenerator;
        private readonly IMapper _mapper;

        public OfferteDataService(IOfferteRepository offerteRepo, IKlantenRepository klantenRepo, IMapper mapper, IOfferteGenerator offerteGenerator )
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

        public async Task<FileResult> AddOfferteForCustomer(OfferteViewModel offerte)
        {
            var entity = _mapper.Map<Offerte>(offerte);

            var retVal = await _offerteRepo.Add(entity);

            var mock = Mock.Offerte();

            var bytes = _offerteGenerator.FillTemplateWithOfferteData(mock);
            
        }
    }
}
