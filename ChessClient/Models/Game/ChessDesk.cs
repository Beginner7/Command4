using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessClient.Models.Game
{
    public class ChessDesk
    {
        public enum ChessColor { Black, White, Empty }
        public struct CellNumber
        {
            public int col, row;
        }
    }
}