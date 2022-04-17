using OFM.BankAppWeb.Data.Context;
using OFM.BankAppWeb.Data.Interfaces;
using OFM.BankAppWeb.Data.Repositories;

namespace OFM.BankAppWeb.Data.UnitOfWork
{
    public class Uow :IUow
    {
        private readonly BankContext _context;

        public Uow(BankContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GetRepository<T>() where T : class,new()
        {
            return new GenericRepository<T>(_context);
        } 
        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
