using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces.Repositories
{
    public interface IKlantenRepository : IRepository<Klant>
    {
        Task<List<Offerte>> GetPreviousOffertes(int klantId);
    }
}
