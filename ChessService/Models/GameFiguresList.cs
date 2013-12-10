using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessService.Models {
    public class GameFiguresList {
        readonly List<Figure> figures;
        public GameFiguresList() {
            figures = new List<Figure>();
        }
        public CurrentGameResult ProcessMove(int xFrom, int yFrom, int xTo, int yTo) {
            List<Figure> figuresCopy;
            return CurrentGameResult.Ok;
        }
    }
}