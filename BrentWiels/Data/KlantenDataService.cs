using AutoMapper;
using BrentWiels.Data.Interfaces;
using BrentWiels.ViewModels;
using DataLayer.Entities;
using DataLayer.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrentWiels.Data
{
    public class KlantenDataService : IKlantenDataService
    {
        private IKlantenRepository _klantenRepo;
        private readonly IMapper _mapper;

        public KlantenDataService(IKlantenRepository klantenRepository, IMapper mapper)
        {
            _klantenRepo = klantenRepository;
            _mapper = mapper;
        }

        public async Task<IList<KlantViewModel>> GetAllCustomers()
        {
            var entities = await _klantenRepo.GetAll();
            return entities.Select(x => _mapper.Map<KlantViewModel>(x)).ToList();
        }

        public async Task<KlantViewModel> AddCustomer(KlantViewModel klant)
        {
            var entity = _mapper.Map<Klant>(klant);
            return _mapper.Map<KlantViewModel>(await _klantenRepo.Add(entity));
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
    }
}
