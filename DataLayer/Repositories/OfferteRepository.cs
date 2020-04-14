using DataLayer.Entities;
using DataLayer.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class OfferteRepository : Repository<Offerte>, IOfferteRepository
    {
        private readonly EntityContext _context;

        public OfferteRepository(EntityContext entityContext) : base(entityContext)
        {
            _context = entityContext;
        }

        public async Task<string> GetNextNummer()
        {
            var year = DateTime.Now.Year;
            
            var lastNummer = (await _context.Offertes.OrderByDescending(x => x.Id).FirstOrDefaultAsync(x => x.CreatedAt > new DateTime(year - 1, 12, 31, 10, 0, 0)))?.OfferteNummer;
            if (lastNummer == null)
            {
                return string.Format($"{year}-{1}");
            }
            return string.Format($"{year}-{lastNummer}");
        }

        public override async Task<Offerte> Add(Offerte offerte) 
        {
            using (var context = _context)
            {
                offerte.KlantId = offerte.Klant.Id;
                offerte.Klant = null;

                _context.Offertes.Add(offerte);
                await _context.SaveChangesAsync();

                return offerte;
            }
        }
    }
}
