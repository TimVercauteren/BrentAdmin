using DataLayer.Entities;
using DataLayer.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public abstract class Repository<T>: IRepository<T> where T : EntityBase
    {
        private readonly EntityContext _dbContext;

        public Repository(EntityContext entityContext)
        {
            _dbContext = entityContext;
        }

        public async virtual Task<IList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async virtual Task<T> Get(int id)
        {
            return (await _dbContext.FindAsync<T>(id));
        }

        public async virtual Task<T> Update(T entity, int id)
        {

            _dbContext.Update<T>(entity);
            entity.ModifiedAt = DateTime.Now;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<T> Add(T entity)
        {
            _dbContext.Add<T>(entity);
            entity.CreatedAt = DateTime.Now;
            entity.ModifiedAt = DateTime.Now;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
