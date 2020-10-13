using BrentWiels.Viewmodels;
using Documents.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrentWiels.Data.Interfaces
{
    public interface IFactuurService
    {
        Task<byte[]> GetFactuurBytes(int factuurId);
        Task AddFactuur(int offerteId, WerkLineViewModel extraWerkline);
        Task<List<FacturenInfo>> GetAllFacturen();
    }
}
