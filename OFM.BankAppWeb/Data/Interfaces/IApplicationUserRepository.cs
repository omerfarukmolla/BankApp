using OFM.BankAppWeb.Data.Entities;
using System.Collections.Generic;

namespace OFM.BankAppWeb.Data.Interfaces
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser> GetAll();
        ApplicationUser GetById(int id);
        ApplicationUser AddAplicationUser(ApplicationUser user);
        ApplicationUser UpdateAplicationUser(ApplicationUser user);
        ApplicationUser DeleteAplicationUser(ApplicationUser user);
        int SaveChange();
    }
}
