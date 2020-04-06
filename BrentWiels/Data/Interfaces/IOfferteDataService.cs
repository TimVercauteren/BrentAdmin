using BrentWiels.Viewmodels;
using System.Threading.Tasks;

namespace BrentWiels.Data.Interfaces
{
    public interface IOfferteDataService
    {
        Task<OfferteViewModel> GetNewOfferteForCustomer(int klandId);
        Task<byte[]> AddOfferteForCustomer(OfferteViewModel offerte);
    }
}
