using BrentWiels.Viewmodels;
using System.Threading.Tasks;

namespace BrentWiels.Data.Interfaces
{
    public interface IOfferteDataService
    {
        Task<OfferteViewModel> GetNewOfferteForCustomer(int klandId);
        Task AddOfferteForCustomer(OfferteViewModel offerte);
        Task<byte[]> GetOfferteXls(int offerteId);
        Task<byte[]> GetOffertePdf(int offerteId);
    }
}
