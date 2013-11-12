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

namespace ChessClient.Tests.Controllers
{
    [TestClass]
    class AccountControllerTest
    {
        [TestMethod]
        public void VarificationLogAndPassword()
        {
            //Arrange
            AccountController controller = new AccountController();
            LoginModel model = new LoginModel()
            {                
                UserName="",
                Password="",
                RememberMe = false             
            };
            //Act
             

        }
    }
}
