using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessService;
using ChessService.Controllers;
using ChessService.Models;

namespace ChessService.Tests.Controllers {
    [TestClass]
    public class GamesControllerTest {
        GamesRepository repository = new GamesRepository();
        Guid gameId;

        [TestInitialize]
        public void Init() {
            Guid gameRequest = repository.GameRequest(Guid.NewGuid());
            gameId = repository.StartGame(gameRequest, Guid.NewGuid(), Guid.NewGuid());
        }

        [TestMethod]
        public void Get() {
            GamesController controller = new GamesController(repository);

            // Act

            IEnumerable<string> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", result.ElementAt(0));
        }

        [TestMethod]
        public void GetById() {
            // Arrange
            GamesController controller = new GamesController(repository);

            // Act
            string result = controller.Get(gameId);

            // Assert
            Assert.AreEqual("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", result);
        }

        [TestMethod]
        public void Post() {
            // Arrange
            GamesController controller = new GamesController(repository);

            // Act
            controller.Post(gameId, "....");

            // Assert
        }
    }
}
