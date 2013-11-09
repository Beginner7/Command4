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
            string[] move;

            move = gameModel.ConvertMove(gameModel.move);
            ViewBag.From = move[0];
            ViewBag.To = move[1];


            if (Request.IsAjaxRequest())
            {
                ViewBag.Show = "Частичное";
                return PartialView();

            }
            else
            {

                ViewBag.Show = "1234";
                return View();
            }
            
        }





    }
}
