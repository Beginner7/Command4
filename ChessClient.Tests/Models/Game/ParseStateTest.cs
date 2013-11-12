using System;
using System.Security.Principal;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessClient.Models.Game;
using ChessClient;
using ChessClient.Controllers;
using ChessClient.Models;
using Common;


namespace ChessClient.Tests.Model
{
    [TestClass]
    public class ParseStateTest
    {
        [TestMethod]
        public void TestStateParsing()
        {
            GameState state = new GameState();
            GameModels m = new GameModels(state);
            Figure f = new Figure();
            f.Type = FigureType.Pawn;
            f.Color = FigureColor.White;
            Assert.AreEqual(m.cells[1, 1], f);
        }
    }
}
