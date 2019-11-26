﻿using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class KlantenRepository : Repository<Klant>, IKlantenRepository
    {
        private EntityContext _entityContext;

        public KlantenRepository(EntityContext entityContext) : base(entityContext)
        {
            _entityContext = entityContext;
        }

        public async override Task<IList<Klant>> GetAll()
        {
            return await _entityContext.Set<Klant>()
                            .Include(k => k.Adres)
                            .Include(k => k.Contact).ToListAsync();
        }

        public async Task<Klant> GetKlant(int id)
        {
            return await _entityContext.Klanten.Where(k => k.Id == id)
                    .Include(kl => kl.Adres)
                    .Include(kl => kl.Contact).FirstOrDefaultAsync();  
        }

        public async Task<List<Offerte>> GetPreviousOffertes(int klantId)
        {
            return await _entityContext.Offertes.Include(t => t.Klant).Where(x => x.Klant.Id == klantId).ToListAsync();

        }
    }
}
