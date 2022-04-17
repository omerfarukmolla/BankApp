using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OFM.BankAppWeb.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(object id);
        List<T> GetAll();
        IQueryable<T> GetQueryable();
    }
}
