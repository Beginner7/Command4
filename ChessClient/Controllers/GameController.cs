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
                throw new InvalidOperationException(result.Exception.GetBaseException().Message);
            }

        }

        [HttpGet]
        public ActionResult ShowGame(Guid gameId) {
            RepositoryResult<GameState> result = repository.Games.GetGame(gameId);
            GameModel gamemodel = new GameModel(result.Value);
            if(result.IsSuccessStatusCode) {
                return View("GameList", result.Value);
            } else {
                return View("GameList", result.Value);
            }
        }

        [HttpPost]
        public ActionResult ShowGame(Guid gameId, [System.Web.Http.FromBody] string move) {
            return null;
        }
    }
}
