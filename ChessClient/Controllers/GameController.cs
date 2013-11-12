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
            RepositoryResult<IEnumerable<GameState>> result = repository.Games.GetGames();
            if(result.IsSuccessStatusCode) { }
            return View(result.Value);
        }

        [HttpPost]
        public ActionResult Index(GameModels gameModel) {
            string[] move;

            move = gameModel.ConvertMove(gameModel.move);
            ViewBag.From = move[0];
            ViewBag.To = move[1];


            if(Request.IsAjaxRequest()) {
                ViewBag.Show = "Частичное";
                return PartialView();

            } else {

                ViewBag.Show = "1234";
                return View();
            }

        }





    }
}
