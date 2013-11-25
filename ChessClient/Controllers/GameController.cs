using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChessClient.DataService;
using ChessClient.Models;
using Common;

namespace ChessClient.Controllers {
    public class GameController : Controller {
        readonly IDataService repository;
        public GameController(IDataService repository) {
            this.repository = repository;
        }

        //
        // GET: /Game/
        [HttpGet]
        public ActionResult Index() {
            GameState gameState = new GameState();
            gameState.GameId = Guid.NewGuid();
            GameModel gameModels = new GameModel(gameState);
            return View("Game", gameModels);

            /*
            RepositoryResult<IEnumerable<GameState>> result = repository.Games.GetGames();
            return View("GameList", result.Value);
             */ 

        }

        [HttpPost]
        public ActionResult Index(GameModel gameModels) {
            //TODO get gamestate from service // gameState = gamestate from service 
         //   gameModels.MakeMove(gameModels.move);
         //   gameModels.Parse(gameModels.gameState.GameStateNotation);

            return View("Game",gameModels);
  
         //   repository.Games.RegisterMove(
        }





    }
}
