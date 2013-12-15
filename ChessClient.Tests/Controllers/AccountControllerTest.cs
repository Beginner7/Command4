using System;
using System.Security.Principal;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessClient;
using ChessClient.Controllers;
using ChessClient.Models;
using ChessClient.DataService;
using Common;

namespace ChessClient.Tests.Controllers {
    [TestClass]
    class AccountControllerTest {
        IDataService ds = new DataServiceForTest();
        [TestMethod]
        public void VerificationLogAndPassword() {
            //Arrange
            AccountController controller = new AccountController(ds);
            User model = new User() {
                Login = "",
                Name = "",
                Password = ""
            };
            //Act


        }
    }
}
