using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<IList<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Update(T entity, int id);
        Task<T> Add(T entity);

    }
}
