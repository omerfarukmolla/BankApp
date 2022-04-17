using Microsoft.AspNetCore.Mvc;
using OFM.BankAppWeb.Data.Context;
using OFM.BankAppWeb.Data.Interfaces;
using OFM.BankAppWeb.Data.Repositories;
using OFM.BankAppWeb.Mapping;

namespace OFM.BankAppWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IApplicationUserMapper _applicationUserMapper;
        public HomeController(BankContext context , IApplicationUserRepository applicationUserRepository, IApplicationUserMapper applicationUserMapper)
        {
            _applicationUserRepository = applicationUserRepository;
            _applicationUserMapper = applicationUserMapper;
        }

        public IActionResult Index()
        {
            return View(_applicationUserMapper.MapToListOfUserList(_applicationUserRepository.GetAll()));
        }
    }
}
