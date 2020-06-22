using DataLayer.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Interfaces.Repositories
{
    public interface IFactuurRepository : IRepository<Factuur>
    {
        Task<Factuur> GetFullFactuur(int factuurId);
        Task<string> GetNextFactuurNumber();
        Task<List<Factuur>> GetAllFromKlant(int klantId);
    }
}
