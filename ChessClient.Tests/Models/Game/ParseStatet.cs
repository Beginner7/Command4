using System;
using System.Security.Principal;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessClient;
using ChessClient.Controllers;
using ChessClient.Models;
using Common;


namespace ChessClient.Tests.Model
{
    [TestClass]
    public class ParsingState
    {
        [TestMethod]
        public void TestStateParsing()
        {
            GameState state = new GameState();
            GameModels m = new GameModels(state);
            Figure f = new Figure();
            
            f.Type = FigureType.Rook;
            f.Color = FigureColor.White;
            Assert.AreEqual(m.cells[7, 7], f);
            
            f.Type = FigureType.Empty;
            f.Color = FigureColor.Empty;
            Assert.AreEqual(m.cells[4,4], f);
            
            f.Type = FigureType.Queen;
            f.Color = FigureColor.Black;
            Assert.AreEqual(m.cells[0,3], f);
        }
    }
}
