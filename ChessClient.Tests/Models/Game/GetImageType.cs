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
namespace ChessClient.Tests
{
    [TestClass]
    public class GetFigureImage
    {
        [TestMethod]
        public void TestGetImageType()
        {
            GameState state = new GameState();
            GameModel m = new GameModel(state);
            string ImageFile="images/pawnblack.png";
            string GetImage = m.GetFigureImage(1, 3).ToLower();
            Assert.AreEqual(GetImage, ImageFile);
        }
    }
}
