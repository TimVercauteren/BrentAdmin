using BrentWiels.Data.Interfaces;
using DataLayer.Interfaces;
using DataLayer.Interfaces.Repositories;
using System;

namespace BrentWiels.Data
{
    public class OfferteDataService : IOfferteDataService
    {
        private readonly IOfferteRepository _repo;

        public OfferteDataService(IOfferteRepository repo)
        {
            _repo = repo;
        }

        public IOfferte GetNewOfferte()
        {
            var nummer = _repo.GetNextNummer();
            throw new NotImplementedException();
        }
    }
}
