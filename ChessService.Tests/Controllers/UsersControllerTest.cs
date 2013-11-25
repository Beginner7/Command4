using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessService;
using ChessService.Controllers;
using ChessService.Models;
using Common;
using System.Collections.Generic;
using System.Linq;

namespace ChessService.Tests.Controllers {
    [TestClass]
    public class UsersControllerTest {

        UsersRepository repository = new UsersRepository();
        Guid userId;

        [TestInitialize]
        public void Init() {
            userId = repository.UserRegister(new Users() { userId = Guid.NewGuid(), Login="username@milov7.ru", Name="ololosha", Password = "123456" });
        }

        [TestMethod]
        public void Get() {
            // Arrange
            UsersController controller = new UsersController(repository);

            // Act
            IEnumerable<Users> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void GetUser() {
            // Arrange
            UsersController controller = new UsersController(repository);

            // Act
            Users result = controller.Get("username@milov7.ru");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("username@milov7.ru", result.Login);
            Assert.AreEqual("ololosha", result.Name);
            Assert.AreEqual("123456", result.Password);
        }


    }
}
