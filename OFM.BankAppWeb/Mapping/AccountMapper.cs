using OFM.BankAppWeb.Data.Entities;
using OFM.BankAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OFM.BankAppWeb.Mapping
{
    public class AccountMapper : IAccountMapper
    {
        public List<AccountListModel> MapToListOfAccount(List<Account> accountList)
        {
            return accountList.Select(x => new AccountListModel
            {
                Id = x.Id,
                AccountNumber = x.AccountNumber,
                ApplicationUserId = x.ApplicationUserId,
                Balance = x.Balance
            }).ToList();
        }

        public AccountListModel MapToAccount(Account account)
        {
            return new AccountListModel
            {
                Id = account.Id,
                AccountNumber = account.AccountNumber,
                ApplicationUserId = account.ApplicationUserId,
                Balance = account.Balance
            };
        }

        public Account MapCreateModelToAccoun(AccountCreateModel accountCreateModel)
        {
            return new Account
            {
                AccountNumber = accountCreateModel.AccountNumber,
                ApplicationUserId = accountCreateModel.ApplicationUserId,
                Balance = accountCreateModel.Balance
            };
        }
    }
}
