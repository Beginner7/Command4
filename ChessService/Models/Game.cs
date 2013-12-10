using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessService.Models {
    public class Game {
        readonly List<Figure> figures;
        public Game() {
            figures = new List<Figure>();
        }
        //public GameState ProcessMove(int xFrom, int yFrom, int xTo, int yTo) {
        //    List<Figure> figuresCopy;
        //}
    }
}