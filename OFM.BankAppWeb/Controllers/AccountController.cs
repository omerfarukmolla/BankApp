using Microsoft.AspNetCore.Mvc;
using OFM.BankAppWeb.Data.Context;
using OFM.BankAppWeb.Data.Entities;
using OFM.BankAppWeb.Data.Interfaces;
using OFM.BankAppWeb.Data.Repositories;
using OFM.BankAppWeb.Mapping;
using OFM.BankAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OFM.BankAppWeb.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IApplicationUserRepository _applicationUserRepository;
        //private readonly IApplicationUserMapper _applicationUserMapper;
        //private readonly IAccontRepository _accontRepository;
        //private readonly IAccountMapper _accountMapper;
        //public AccountController(IApplicationUserMapper applicationUserMapper , IApplicationUserRepository applicationUserRepository , IAccontRepository accontRepository, IAccountMapper accountMapper)
        //{
        //    _applicationUserRepository = applicationUserRepository;
        //    _applicationUserMapper = applicationUserMapper;
        //    _accontRepository = accontRepository;
        //    _accountMapper = accountMapper;
        //}
        private readonly IGenericRepository<Account> _accountRepo;
        private readonly IGenericRepository<ApplicationUser> _userRepo;
        
        public AccountController(IGenericRepository<Account> accountRepo, IGenericRepository<ApplicationUser> userRepo)
        {
            _accountRepo = accountRepo;
            _userRepo = userRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(int id)
        {
            var userInfo = _userRepo.GetById(id);
            return View(new UserListModel{
                Id = userInfo.Id,
                Name = userInfo.Name,
                Surname = userInfo.Surname
            });
        }
            
        [HttpPost]
        public IActionResult Create(AccountCreateModel accountCreateModel)
        {
            //_context.Accounts.Add(new Data.Entities.Account
            //{
            //    AccountNumber=accountCreateModel.AccountNumber,
            //    ApplicationUserId=accountCreateModel.ApplicationUserId,
            //    Balance=accountCreateModel.Balance
            //});

            //_context.SaveChanges();
            _accountRepo.Create(new Account
            {
                Balance = accountCreateModel.Balance,
                ApplicationUserId = accountCreateModel.ApplicationUserId,
                AccountNumber = accountCreateModel.AccountNumber
            });

            return RedirectToAction("Index", "home");
        }
    }
}
