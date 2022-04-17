using OFM.BankAppWeb.Data.Context;
using OFM.BankAppWeb.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OFM.BankAppWeb.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class , new() 
    {
        private readonly BankContext _context;

        public GenericRepository(BankContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        public T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}
