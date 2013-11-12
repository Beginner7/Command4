using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessClient;
using ChessClient.Controllers;
using ChessClient.DataService;
using Common;

namespace ChessClient.Tests.Controllers {
    [TestClass]
    public class GameControllerTest {
        IDataService ds = new DataServiceForTest();
        Guid gameId=Guid.NewGuid();

        [TestInitialize]
        public void Init() {
            ds.Games.StartGame(gameId, Guid.NewGuid(), Guid.NewGuid());
        }
        [TestMethod]
        public void Index() {
            // Arrange
            GameController controller = new GameController(ds);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            IEnumerable<GameState> games=(IEnumerable<GameState>)result.Model;
            Assert.AreEqual(gameId, games.First().GameId);
        }
        [TestMethod]
        public void Move()
        {
            // Arrange
            GameController controller = new GameController(ds);

            // Act
            //ViewResult result = controller.

            // Assert
            //IEnumerable<GameState> games = (IEnumerable<GameState>)result.Model;
        }
    }
}
