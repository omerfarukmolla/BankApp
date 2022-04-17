using OFM.BankAppWeb.Data.Entities;
using OFM.BankAppWeb.Models;
using System.Collections.Generic;

namespace OFM.BankAppWeb.Mapping
{
    public interface IApplicationUserMapper
    {
        List<UserListModel> MapToListOfUserList(List<ApplicationUser> applicationUsers);
        UserListModel MapToUser(ApplicationUser user);
    }
}
