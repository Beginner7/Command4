using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using ChessClient.Models;
using ChessClient.DataService;
using Common;

namespace ChessClient.Controllers {
    [Authorize]
    public class LoginController : Controller {
        readonly IDataService repository;

        public LoginController(IDataService repository) {
            this.repository = repository;
        }
        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Index() {
            AccountModel accountModel = new AccountModel();
            return View("Login", accountModel);
        }

        [HttpPost]
        public ActionResult Index(string login, string password) {
            AccountModel accountModel = new AccountModel();
            return View("Login", accountModel);
        }

    }
}
