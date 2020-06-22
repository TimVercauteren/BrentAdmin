using AutoMapper;
using BrentWiels.Data.Interfaces;
using BrentWiels.Viewmodels;
using DataLayer.Entities;
using DataLayer.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrentWiels.Data
{
    public class KlantenDataService : IKlantenDataService
    {
        private IKlantenRepository _klantenRepo;
        private readonly IOfferteRepository _offerteRepo;
        private readonly IMapper _mapper;
        private readonly IFactuurRepository _facturenRepo;

        public KlantenDataService(IKlantenRepository klantenRepository, IOfferteRepository offerteRepository, IFactuurRepository factuurRepository, IMapper mapper)
        {
            _klantenRepo = klantenRepository;
            _offerteRepo = offerteRepository;
            _facturenRepo = factuurRepository;
            _mapper = mapper;
        }

        public async Task<IList<KlantViewModel>> GetAllCustomers()
        {
            var entities = await _klantenRepo.GetAll();
            return entities.Select(x => _mapper.Map<KlantViewModel>(x)).ToList();
        }

        public async Task<KlantViewModel> AddCustomer(KlantViewModel klant)
        {
            var nextNumber = _klantenRepo.GetNextAvailableKlantenRefNumber();
            klant.KlantenRef = (await nextNumber).ToString("00000");
            var entity = _mapper.Map<Klant>(klant);
            return _mapper.Map<KlantViewModel>(await _klantenRepo.Add(entity));
        }

        public async Task RemoveCustomer(int id)
        {
            await _klantenRepo.Remove(id);
        }

        public async Task<KlantViewModel> UpdateCustomer(KlantViewModel klant, int klantId)
        {
            var entity = _mapper.Map<Klant>(klant);
            return _mapper.Map<KlantViewModel>(await _klantenRepo.Update(entity, klantId));
        }

        public async Task<KlantViewModel> GetCustomer(int id)
        {
            var entity = await _klantenRepo.Get(id);
            return _mapper.Map<KlantViewModel>(entity);
        }

        public async Task<IList<OfferteCompactDto>> GetOffertesForClient(int klantId)
        {
            var list = await _offerteRepo.GetAllFromKlant(klantId);
            return list.Select(x => _mapper.Map<OfferteCompactDto>(x)).ToList();
        }

        public async Task<IList<FactuurCompactDto>> GetFacturenForClient(int klantId)
        {
            var list = await _facturenRepo.GetAllFromKlant(klantId);
            return list.Select(x => _mapper.Map<FactuurCompactDto>(x)).ToList();
        }
    }
}
