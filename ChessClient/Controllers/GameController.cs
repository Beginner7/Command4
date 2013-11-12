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
            return Index(Guid.NewGuid());

            /*
            RepositoryResult<IEnumerable<GameState>> result = repository.Games.GetGames();
            return View("GameList", result.Value);
             */ 

        }

        [HttpPost]
        public ActionResult Index(Guid gameOid) {
            //TODO get gamestate from service
            GameState gameState = new GameState();
            GameModels gameModels = new GameModels(gameState);
            //string[] move;

            //move = gameModel.ConvertMove(gameModel.move);
            //ViewBag.From = move[0];
            //ViewBag.To = move[1];
            /*
            if(Request.IsAjaxRequest()) {
                ViewBag.Show = "Частичное";
                return PartialView();

            }*/
            return View("Game", gameModels);
  

        }





    }
}
