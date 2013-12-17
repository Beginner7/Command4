using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Common;

namespace ChessService.Models {
    public class GameFiguresList {
        readonly List<Figure> figures;
        readonly GameState gameState;
        public GameState GameState { 
            get {
                return gameState;
            } }
        public GameFiguresList() {
            figures = new List<Figure>();
        }
        public GameFiguresList(GameState gameState) {
            figures = new List<Figure>();
            this.gameState = gameState;
        }
        public CurrentGameResult ProcessMove(GameMove move) {
            int[] coordinates = new int[4];
            coordinates = move.MoveParse();

            Figure currentFigure=null;
            foreach(var figure in figures) {
                if(figure.IsIt(coordinates[0], coordinates[1])) {
                    currentFigure = figure;
                    break;
                }
            }
            if(currentFigure == null)
                throw new ArgumentException();

            List<int[]> path = currentFigure.GeneratePath(coordinates[2],coordinates[3]);

            foreach(var cell in path) {
                //cheackFreeCell[0];
            }

            List<Figure> figuresCopy;
            return CurrentGameResult.Ok;
        }
        
    }
}