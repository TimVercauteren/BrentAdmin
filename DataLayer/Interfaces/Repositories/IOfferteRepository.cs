using DataLayer.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Interfaces.Repositories
{
    public interface IOfferteRepository : IRepository<Offerte>
    {
        Task<string> GetNextNummer();
        Task<Offerte> GetFullOfferte(int offerteId);
    }
}
