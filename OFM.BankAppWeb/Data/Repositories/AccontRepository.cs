using OFM.BankAppWeb.Data.Context;
using OFM.BankAppWeb.Data.Entities;
using OFM.BankAppWeb.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OFM.BankAppWeb.Data.Repositories
{
    public class AccontRepository : IAccontRepository
    {
        private readonly BankContext _context;

        public AccontRepository(BankContext context)
        {
            _context = context;
        }

        public Account AddAccount(Account account)
        {
            var addedAccount = _context.Accounts.Add(account);
            return addedAccount.Entity;
        }

        public Account DeleteAccount(Account account)
        {
            _context.Accounts.Remove(account);
            return account;
        }

        public List<Account> GetAll()
        {
            return _context.Accounts.ToList();
        }

        public Account GetById(int id)
        {
            return _context.Accounts.FirstOrDefault(x => x.Id == id);
        }

        public int SaveChange()
        {
            return _context.SaveChanges();
        }

        public Account UpdateAccount(Account account)
        {
            Account updatedAccount = this.GetById(account.Id);
            updatedAccount.AccountNumber = account.AccountNumber;
            updatedAccount.Balance = account.Balance;
            updatedAccount.ApplicationUserId = account.ApplicationUserId;
            _context.Accounts.Update(updatedAccount);
            return updatedAccount;
        }
    }
}
