using BrentWiels.Viewmodels;
using Microsoft.AspNetCore.Html;
using System.Threading.Tasks;

namespace BrentWiels.Data.Interfaces
{
    public interface IOfferteDataService
    {
        Task<OfferteViewModel> GetNewOfferteForCustomer(int klandId);
        Task AddOfferteForCustomer(OfferteViewModel offerte);
        Task<byte[]> GetOfferteBytes(int offerteId);
        Task<string> GetOfferteHtml(int offerteId);
        Task<OfferteViewModel> GetOffertePreview(int offerteId);
        Task DeleteOfferte(int offerteId);
    }
}
