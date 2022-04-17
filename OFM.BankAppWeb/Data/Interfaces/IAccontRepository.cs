using OFM.BankAppWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OFM.BankAppWeb.Data.Interfaces
{
    public interface IAccontRepository
    {
        List<Account> GetAll();
        Account GetById(int id);
        Account AddAccount(Account account);
        Account UpdateAccount(Account account);
        Account DeleteAccount(Account account);
        int SaveChange();
    }
}
