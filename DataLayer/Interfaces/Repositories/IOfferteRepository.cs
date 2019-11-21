using DataLayer.Entities;
using System.Threading.Tasks;

namespace DataLayer.Interfaces.Repositories
{
    public interface IOfferteRepository : IRepository<Offerte>
    {
        Task<string> GetNextNummer();
    }
}
