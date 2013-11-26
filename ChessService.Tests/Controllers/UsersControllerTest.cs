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
        public void GetUsers() {
            // Arrange
            UsersController controller = new UsersController(repository);

            Users user = new Users();
            user.Login = "username@milov7.ru";
            user.Password = "123456";
            user.Name = "ololosha";
            user.userId = Guid.NewGuid();
            controller.Post(user);



            user.userId = Guid.NewGuid();
            controller.Post(user);

            user.userId = Guid.NewGuid();
            controller.Post(user);

            // Act
            IEnumerable<Users> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void GetUser() {
            // Arrange
            UsersController controller = new UsersController(repository);
            Users user=new Users();
            user.Login = "username@milov7.ru";
            user.Password = "123456";
            user.Name = "ololosha";
            user.userId=Guid.NewGuid();
            controller.Post(user);

            // Act

            Users result = controller.Get("username@milov7.ru");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("username@milov7.ru", result.Login);
            Assert.AreEqual("ololosha", result.Name);
            Assert.AreEqual("123456", result.Password);
        }

        [TestMethod]
        public void GetUserById() {
            // Arrange
            UsersController controller = new UsersController(repository);
            Users user = new Users();
            user.Login = "username@milov7.ru";
            user.Password = "123456";
            user.Name = "ololosha";
            Guid current_guid = Guid.NewGuid();
            user.userId = current_guid;
            

            // Act

            controller.Post(user);
            Users result = controller.Get(current_guid);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("username@milov7.ru", result.Login);
            Assert.AreEqual("ololosha", result.Name);
            Assert.AreEqual("123456", result.Password);
        }


        [TestMethod]
        public void UserRegister() {
            // Arrange
            UsersController controller = new UsersController(repository);
            Users user = new Users();
            user.Login = "username@milov7.ru";
            user.Password = "123456";
            user.Name = "ololosha";

            Guid current_guid = Guid.NewGuid();
            user.userId = current_guid;

            // Act

            controller.Post(user);
            Users result = controller.Get(current_guid);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("username@milov7.ru", result.Login);
            Assert.AreEqual("ololosha", result.Name);
            Assert.AreEqual("123456", result.Password);
            Assert.AreEqual(current_guid, user.userId);
        }

        [TestMethod]
        public void UserUpdate() {
            // Arrange
            UsersController controller = new UsersController(repository);
            Users user = new Users();
            user.Login = "username@milov7.ru";
            user.Password = "123456";
            user.Name = "ololosha";

            Guid current_guid = Guid.NewGuid();
            user.userId = current_guid;

            controller.Post(user);

            // Act

            user.Name = "IAmWinner";
            user.Password = "z7vBA2a1";

            controller.Put(user);

            Users result = controller.Get(current_guid);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("username@milov7.ru", result.Login);
            Assert.AreEqual("IAmWinner", result.Name);
            Assert.AreEqual("z7vBA2a1", result.Password);
            Assert.AreEqual(current_guid, user.userId);
        }



    }
}
