using BrentWiels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrentWiels.Data.Interfaces
{
    public interface IKlantenDataService 
    {
        Task<IList<KlantViewModel>> GetAllCustomers();
        Task<KlantViewModel> AddCustomer(KlantViewModel klant);
        Task<KlantViewModel> UpdateCustomer(KlantViewModel klant, int klantId);
        Task<KlantViewModel> GetCustomer(int id);
    }
}
