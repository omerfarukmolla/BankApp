using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OFM.BankAppWeb.Data.Context;
using OFM.BankAppWeb.Data.Entities;
using OFM.BankAppWeb.Data.Interfaces;
using OFM.BankAppWeb.Data.Repositories;
using OFM.BankAppWeb.Data.UnitOfWork;
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
        //private readonly IGenericRepository<Account> _accountRepo;
        //private readonly IGenericRepository<ApplicationUser> _userRepo;

        //public AccountController(IGenericRepository<Account> accountRepo, IGenericRepository<ApplicationUser> userRepo)
        //{
        //    _accountRepo = accountRepo;
        //    _userRepo = userRepo;
        //}
        private readonly IUow _uow;

        public AccountController(IUow uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create(int id)
        {
            var userInfo = _uow.GetRepository<ApplicationUser>().GetById(id);
            return View(new UserListModel {
                Id = userInfo.Id,
                Name = userInfo.Name,
                Surname = userInfo.Surname
            });
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel accountCreateModel)
        {
            _uow.GetRepository<Account>().Create(new Account
            {
                Balance = accountCreateModel.Balance,
                ApplicationUserId = accountCreateModel.ApplicationUserId,
                AccountNumber = accountCreateModel.AccountNumber
            });
            _uow.SaveChange();

            return RedirectToAction("Index", "home");
        }

        [HttpGet]
        public IActionResult GetByUserId(int userId)
        {
            var query = _uow.GetRepository<Account>().GetQueryable();
            var accountList = query.Where(x => x.ApplicationUserId == userId).ToList();

            var user = _uow.GetRepository<ApplicationUser>().GetById(userId);

            ViewBag.FullName = user.Name + " " + user.Surname;
            var list = new List<AccountListModel>();

            foreach (var account in accountList)
            {
                list.Add(new()
                {
                    AccountNumber = account.AccountNumber,
                    ApplicationUserId= account.ApplicationUserId,
                    Balance = account.Balance,
                    Id = account.Id
                });
            }
            return View(list);
        }

        [HttpGet]
        public IActionResult SendMoney(int accountId)
        {
            var query = _uow.GetRepository<Account>().GetQueryable();

            var accounts = query.Where(x => x.Id != accountId).ToList();

            var list = new List<AccountListModel>();

            ViewBag.SenderId = accountId;

            foreach (var account in accounts)
            {
                list.Add(new ()
                {
                    AccountNumber = account.AccountNumber,
                    Balance = account.Balance, 
                    ApplicationUserId= account.ApplicationUserId,
                    Id= account.Id
                });
            }

            return View(new SelectList(list, "Id", "AccountNumber"));

        }

        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel model)
        {
            var sender = _uow.GetRepository<Account>().GetById(model.SenderId);
            sender.Balance -= model.Amount;
            _uow.GetRepository<Account>().Update(sender);

            var account = _uow.GetRepository<Account>().GetById(model.AccountId);
            account.Balance += model.Amount;
            _uow.GetRepository<Account>().Update(account);

            _uow.SaveChange();
            return RedirectToAction("Index","Home");
        }
    }
}
