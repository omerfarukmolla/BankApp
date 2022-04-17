using OFM.BankAppWeb.Data.Context;
using OFM.BankAppWeb.Data.Entities;
using OFM.BankAppWeb.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OFM.BankAppWeb.Data.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly BankContext _context;

        public ApplicationUserRepository(BankContext context)
        {
            _context = context;
        }

        public List<ApplicationUser> GetAll()
        {
            return _context.ApplicationUsers.ToList();
        }
        public ApplicationUser GetById(int id)
        {
            return _context.ApplicationUsers.SingleOrDefault(x => x.Id == id);
        }

        public ApplicationUser AddAplicationUser(ApplicationUser user)
        {
            var addedAplicationUser = _context.ApplicationUsers.Add(user);
            return addedAplicationUser.Entity;

        }
        public ApplicationUser UpdateAplicationUser(ApplicationUser user)
        {
            var updatedUser = _context.ApplicationUsers.FirstOrDefault(x => x.Id == user.Id);
            updatedUser.Name = user.Name;
            updatedUser.Surname = user.Surname;
            _context.ApplicationUsers.Update(updatedUser);
            return updatedUser;
        }

        public ApplicationUser DeleteAplicationUser(ApplicationUser user)
        {
            _context.ApplicationUsers.Remove(user);
            return user;
        }
        public int SaveChange()
        {
            return _context.SaveChanges();
        }

    }
}
