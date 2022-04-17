using OFM.BankAppWeb.Data.Entities;
using OFM.BankAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OFM.BankAppWeb.Mapping
{
    public interface IAccountMapper
    {
        List<AccountListModel> MapToListOfAccount(List<Account> accountList);
        AccountListModel MapToAccount(Account account);
        Account MapCreateModelToAccoun(AccountCreateModel accountCreateModel);

    }
}
