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
        public void GameUpdate() {
            GameMove move = new GameMove() { MoveNotation = "a2 a4" };
            // Arrange
            GamesController controller = new GamesController(repository);
      
            // Act
            GameState updatedGame = controller.Get(gameId);
            List<GameMove> moves = new List<GameMove>(updatedGame.Moves);
            moves.Add(move);
            updatedGame.Moves = moves;
            controller.Put(updatedGame);
            updatedGame = controller.Get(gameId);

            // Assert
            GameState game = new GameState();
            game.RegisterMove(move);
            Assert.AreEqual(game.GameStateNotation, updatedGame.GameStateNotation);
        }

        [TestMethod]
        public void CheckColorOfCurrentPlayer() {
            // Arrange
            GamesController controller = new GamesController(repository);
            GameState game = controller.Get(gameId);
            List<GameMove> moves1 = new List<GameMove>(game.Moves);   // for 0 moves
            List<GameMove> moves2 = new List<GameMove>(game.Moves);   // for 1 move 
            List<GameMove> moves3 = new List<GameMove>(game.Moves);   // for 2 moves  

            GameMove move = new GameMove() { MoveNotation = "a2 a4" };
            moves2.Add(move); moves3.Add(move); moves3.Add(move);

            // Act
            FigureColor result1 = ChessOperations.CheckColorOfCurrentPlayer(moves1);
            FigureColor result2 = ChessOperations.CheckColorOfCurrentPlayer(moves2);
            FigureColor result3 = ChessOperations.CheckColorOfCurrentPlayer(moves3);

            // Assert
            Assert.AreEqual(FigureColor.White, result1);
            Assert.AreEqual(FigureColor.Black, result2);
            Assert.AreEqual(FigureColor.White, result3);
        }

        [TestMethod]
        public void MoveCheckCells() {
            // Arrange
            GamesController controller = new GamesController(repository);
            GameState game = controller.Get(gameId);
            List<GameMove> moves = new List<GameMove>(game.Moves);

            Figure[,] cells = new Figure[8, 8];
            ChessOperations.Parse(game.GameStateNotation);

            // Act
           
            Enum result1 = ChessOperations.MoveCheckCells(0, 2, 0, 4, cells, FigureColor.White);
            //Enum result2 = ChessOperations.MoveCheckCells(0, 4, 0, 5, cells, FigureColor.White);

            Enum result3 = ChessOperations.MoveCheckCells(0, 7, 0, 5, cells, FigureColor.Black);

            // Assert
            Assert.AreEqual(ResultMessage.GoodMove, result1);
            //Assert.AreEqual(ResultMessage.NotHaveFigure, result2);
            Assert.AreEqual(ResultMessage.NotYourFigure, result3);
        }
    }
}
