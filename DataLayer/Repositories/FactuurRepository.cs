using DataLayer.Entities;
using DataLayer.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class FactuurRepository : Repository<Factuur>, IFactuurRepository
    {
        private EntityContext _context;
        private readonly IOfferteRepository _offerteRepo;

        public FactuurRepository(EntityContext entityContext, IOfferteRepository offerteRepository) : base(entityContext)
        {
            _context = entityContext;
            _offerteRepo = offerteRepository;
        }

        public async Task<Factuur> GetFullFactuur(int factuurId)
        {
            var factuur = _context.Facturen
                .Include(x => x.ExtraWerklijn)
                .FirstOrDefault(x => x.Id == factuurId);

            var offerteId = factuur?.Offerte?.Id;

            if (!offerteId.HasValue)
            {
                offerteId = factuur.OfferteId;
            }

            if (offerteId.HasValue && offerteId != 0)
            {
                var offerte = await _offerteRepo.GetFullOfferte(offerteId.Value);
                factuur.Offerte = offerte;
            }

            return factuur;
        }

        public async Task<string> GetNextFactuurNumber()
        {
            var thisYear = DateTime.Now.Year;
            var lastNumber = (await _context.Facturen.Where(x => x.CreatedAt > new DateTime(thisYear - 1, 12, 31) && x.CreatedAt > new DateTime(2021, 3, 3)).OrderBy(x => x.Id).LastOrDefaultAsync())?.FactuurNummer;

            if (string.IsNullOrEmpty(lastNumber) || !lastNumber.Contains(thisYear.ToString()))
            {
                return $"001-{thisYear}";
            }

            var number = int.Parse(lastNumber.Replace($"-{thisYear}", ""));

            return $"{++number:000}-{thisYear}";
        }

        public async Task<List<Factuur>> GetAllFromKlant(int klantId)
        {
            return await _context.Facturen
                .Include(x => x.Offerte)
                .Where(x => x.Offerte.KlantId == klantId && !x.Offerte.IsDeleted).ToListAsync();
        }
    }
}
