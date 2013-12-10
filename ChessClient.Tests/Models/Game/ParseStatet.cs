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
    //[TestClass]
    //public class ParsingState
    //{
    //    [TestMethod]
    //    //public void TestStateParsing()
    //    //{

    //    //    GameState state = new GameState();
    //    //    GameModel m = new GameModel(state);
    //    //    Figure f = new Figure();
            
    //    //    f.Type = FigureType.Rook;
    //    //    f.Color = FigureColor.White;
    //    //    Assert.AreEqual(m.cells[7, 7], f);
            
    //    //    f.Type = FigureType.Empty;
    //    //    f.Color = FigureColor.Empty;
    //    //    Assert.AreEqual(m.cells[4,4], f);
     
    //    //    f.Type = FigureType.Queen;
    //    //    f.Color = FigureColor.Black;
    //    //    Assert.AreEqual(m.cells[0,3], f);

    //    //    state.GameStateNotation = "2QR1B2/rpb2p1q/p7/2PBk1P1/p3N2r/2Ppn1P1/KN2b3/4R3 w KQkq - 0 1";
    //    //    GameModel model = new GameModel(state);

    //    //    f.Type = FigureType.Queen;
    //    //    f.Color = FigureColor.White;
    //    //    Assert.AreEqual(model.cells[0, 2], f);

    //    //    f.Type = FigureType.Empty;
    //    //    f.Color = FigureColor.Empty;
    //    //    Assert.AreEqual(model.cells[2, 2], f);


    //    //    f.Type = FigureType.Pawn;
    //    //    f.Color = FigureColor.Black;
    //    //    Assert.AreEqual(model.cells[4, 0], f);
        
    //    //}
    //}
}
