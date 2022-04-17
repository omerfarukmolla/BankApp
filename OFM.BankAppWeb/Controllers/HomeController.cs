using Microsoft.AspNetCore.Mvc;
using OFM.BankAppWeb.Data.Context;
using OFM.BankAppWeb.Data.Entities;
using OFM.BankAppWeb.Data.Interfaces;
using OFM.BankAppWeb.Data.Repositories;
using OFM.BankAppWeb.Data.UnitOfWork;
using OFM.BankAppWeb.Mapping;

namespace OFM.BankAppWeb.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IApplicationUserMapper _applicationUserMapper;
        private readonly IUow _uow;
        public HomeController(BankContext context, IApplicationUserMapper applicationUserMapper, IUow uow)
        {
            _applicationUserMapper = applicationUserMapper;
            _uow = uow;
        }

        public IActionResult Index()
        {
            return View(_applicationUserMapper.MapToListOfUserList(_uow.GetRepository<ApplicationUser>().GetAll()));
        }
    }
}
