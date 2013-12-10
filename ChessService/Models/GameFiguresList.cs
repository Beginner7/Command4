using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace ChessService.Models {
    public class GameFiguresList {
        readonly List<Figure> figures;
        public GameState GameState { get; set; }
        public GameFiguresList() {
            figures = new List<Figure>();
        }
        public GameFiguresList(GameState gameState) {
            figures = new List<Figure>();
        }
        public CurrentGameResult ProcessMove(GameMove move) {
            List<Figure> figuresCopy;
            return CurrentGameResult.Ok;
        }
    }
}