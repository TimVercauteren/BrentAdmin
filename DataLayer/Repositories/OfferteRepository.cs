using DataLayer.Entities;
using DataLayer.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            else
            {
                var number = lastNummer.Replace($"{year}-", "");
                var nextNumber = int.Parse(number) + 1;

                return string.Format($"{year}-{nextNumber}");
            }
        }

        public override async Task<Offerte> Add(Offerte offerte)
        {

            offerte.KlantId = offerte.Klant.Id;
            offerte.Klant = null;

            offerte.CreatedAt = DateTime.Now;
            offerte.ModifiedAt = offerte.CreatedAt;

            _context.Offertes.Add(offerte);
            await _context.SaveChangesAsync();

            return offerte;

        }

        public async Task<Offerte> GetFullOfferte(int offerteId)
        {
            var offerte = _context.Offertes.Where(x => x.Id == offerteId)
                .Include(x => x.Klant)
                    .ThenInclude(y => y.Contact)
                .Include(x => x.Klant)
                    .ThenInclude(y => y.Adres)
                .Include(x => x.Werklijnen)
                    .ThenInclude(y => y.Omschrijving);

            return await offerte.FirstOrDefaultAsync();
        }

        public async Task<IList<Offerte>> GetAllFromKlant(int klantId)
        {
            return await _context.Offertes.Where(x => x.KlantId == klantId).ToListAsync();
        }
    }
}
