using OFM.BankAppWeb.Data.Entities;
using OFM.BankAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OFM.BankAppWeb.Mapping
{
    public class ApplicationUserMapper : IApplicationUserMapper
    {
        public List<UserListModel> MapToListOfUserList(List<ApplicationUser> applicationUsers)
        {
            return applicationUsers.Select(x => new UserListModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname
            }).ToList();
        }

        public UserListModel MapToUser(ApplicationUser user)
        {
            return new UserListModel
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname
            };
        }
    }
}
