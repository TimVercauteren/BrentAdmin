using BrentWiels.Viewmodels;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrentWiels.Data.Interfaces
{
    public interface IOfferteDataService
    {
        Task<OfferteViewModel> GetNewOfferteForCustomer(int klandId);
    }
}
