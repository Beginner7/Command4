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

            Figure figureFrom = GetFigureByCoordinate(coordinates[0], coordinates[1]);
            Figure figureTo = GetFigureByCoordinate(coordinates[2], coordinates[3]);
            if(figureFrom == null)
                throw new ArgumentException();
            if(figureTo != null && figureFrom.Color == figureTo.Color)
                return CurrentGameResult.YourFigureInCellTo;

            List<int[]> path = figureFrom.GeneratePath(coordinates[2], coordinates[3]);

            Figure figureForCheck = null;
            foreach(var cell in path) {
                foreach(var figureCheck in figures) {
                    if(figureCheck.IsIt(cell[0], cell[1])) {
                        figureForCheck = figureCheck;
                        break;
                    }
                }
                if(figureForCheck != null) return CurrentGameResult.BarrierInThePath;
            }

            figureTo.Coordinate=figureFrom.Coordinate;

            gameState.GameStateNotation = "xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/xxxxxxxx/ w KQkq - 0 1";
            for(int i = 0; i < 8; i++) {
                for(int j = 0; j < 8; j++) {
                    if(GetFigureByCoordinate(i, j) != null) {
                        //gameState.GameStateNotation += GetFigureByCoordinate(i, j).Notation;
                    }
                }
            }
            //gameState.GameStateNotation = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

            List<Figure> figuresCopy;
            return CurrentGameResult.Ok;
        }

        private Figure GetFigureByCoordinate(int x, int y) {
            Figure figureTo = null;
            foreach(var figure in figures) {
                if(figure.IsIt(x, y)) {
                    figureTo = figure;
                    break;
                }
            }
            return figureTo;
        }

    }
}