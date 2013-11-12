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
using Common;

namespace ChessService.Tests.Controllers {
    [TestClass]
    public class GamesControllerTest {
        GamesRepository repository = new GamesRepository();
        Guid gameId;

        [TestInitialize]
        public void Init() {
            gameId = repository.StartGame(new GameState() { GameId = gameId, BlackGamer = Guid.NewGuid(), WhiteGamer = Guid.NewGuid() });
        }

        [TestMethod]
        public void Get() {
            // Arrange
            GamesController controller = new GamesController(repository);

            // Act
            IEnumerable<GameState> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", result.ElementAt(0).GameStateNotation);
        }

        [TestMethod]
        public void GetById() {
            // Arrange
            GamesController controller = new GamesController(repository);

            // Act
            GameState result = controller.Get(gameId);

            // Assert
            Assert.AreEqual("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", result.GameStateNotation);
        }

        [TestMethod]
        public void Create() {
            // Arrange
            GamesController controller = new GamesController(repository);

            // Act
            Guid newGameId = Guid.NewGuid();
            Guid newBlackGamer = Guid.NewGuid();
            Guid newWhiteGamer = Guid.NewGuid();
            controller.Post(new GameState() { GameId = newGameId, BlackGamer = newBlackGamer, WhiteGamer = newWhiteGamer });
            GameState game = controller.Get(newGameId);

            // Assert
            Assert.AreEqual("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", game.GameStateNotation);
            Assert.AreEqual(newGameId, game.GameId);
            Assert.AreEqual(newBlackGamer, game.BlackGamer);
            Assert.AreEqual(newWhiteGamer, game.WhiteGamer);
        }

        [TestMethod]
        public void Update() {
            // Arrange
            GamesController controller = new GamesController(repository);
            GameState game = controller.Get(gameId);
            List<GameMove> moves = new List<GameMove>(game.Moves);
            moves.Add(new GameMove() { MoveNotation = "..." });
            game.Moves = moves;
            controller.Put(game);

            // Act
            GameState updatedGame = controller.Get(gameId);

            // Assert
        }
    }
}
