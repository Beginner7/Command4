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
        // GameRepository gamerepository = new GameRepository("name","baseurl");
        readonly IDataService repository;

        public GameController(IDataService repository) {
            this.repository = repository;
        }

        //
        // GET: /Game/
        [HttpGet]
        public ActionResult Index() {

            RepositoryResult<IEnumerable<GameState>> result = repository.Games.GetGames();
            if(result.IsSuccessStatusCode) {
                return View("GameList", result.Value);
            } else {
                return View("GameList", result.Value);
            }
        }

        [HttpGet]
        public ActionResult ShowGame(Guid gameId) {
            RepositoryResult<GameState> result = repository.Games.GetGame(gameId);
            GameModel gamemodel = new GameModel(result.Value);
            if(result.IsSuccessStatusCode) {
                return View("Game", gamemodel);
            }
            return View("Game", gamemodel);
        }

        [HttpPost]
        public ActionResult ShowGame(Guid gameId, [System.Web.Http.FromBody] string move) {
            GameMove gameMove = new GameMove();
            gameMove.MoveNotation = move;
            RepositoryResult resultMoveRegister = repository.Games.RegisterMove(gameId, gameMove);
            if(!resultMoveRegister.IsSuccessStatusCode)
                throw new InvalidOperationException(resultMoveRegister.Exception.GetBaseException().Message);
            RepositoryResult<GameState> resultGameLoad = repository.Games.GetGame(gameId);
            GameModel gamemodel = new GameModel(resultGameLoad.Value);
            if(resultMoveRegister.IsSuccessStatusCode) {
                return View("Game", gamemodel);
            }
            return View("Game", gamemodel);
        }
    }
}
