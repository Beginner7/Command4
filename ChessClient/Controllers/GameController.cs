using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChessClient.Models;

namespace ChessClient.Controllers
{
    public class GameController : Controller
    {
        //
        // GET: /Game/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(GameModels gameModel)
        {
            ViewBag.Result = gameModel.move;
            return View();
        }



    }
}
