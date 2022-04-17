using OFM.BankAppWeb.Data.Interfaces;

namespace OFM.BankAppWeb.Data.UnitOfWork
{
    public interface IUow
    {
        IGenericRepository<T> GetRepository<T>() where T : class, new();
        void SaveChange();
    }
}