using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessService.Tests.Models
{
    [TestClass]
    public class ChessDeskTest
    {
        [TestMethod]
        public void CellToInt()
        {
            // Arrange
            string cell = "F7";


            // Act
            int cellInt = ChessService.Models.ChessDesk.CellToInt(cell);

            // Assert
            Assert.AreEqual(cellInt, 46);
        }

        [TestMethod]
        public void SetInitialStateDesk()
        {
            // Arrange


            // Act
            ChessService.Models.ChessDesk.Cell[] Desk = ChessService.Models.ChessDesk.SetInitialStateDesk();

            // Assert
            Assert.AreEqual(Desk[3].figureColor, true);
            Assert.AreEqual(Desk[62].figureColor, false);
            Assert.AreEqual(Desk[0].figureType, (int)ChessService.Models.ChessDesk.Figure.rook);
        }
    }
}
