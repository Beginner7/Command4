using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public enum FigureColor { White, Black, Empty }
    public enum FigureType { Pawn, Rook, Knight, Bishop, Queen, King, Empty }
    public enum ResultMessage { GoodMove, NotHaveFigure, NotYourFigure }
    public struct Figure {
        public FigureColor Color;
        public FigureType Type;
    }
    public static class ChessOperations {

        public static Figure[,] Parse(string Notation) {
            const char EOLN = ' ';
            Figure[,] cells = new Figure[8, 8];
            int counter = 0, rowNumber = 0, value = 0, index = 0;
            char cursor = Notation[0];
            bool result = false;
            while(cursor != EOLN) {
                if(cursor == '/') {
                    counter++;
                    cursor = Notation[counter];
                    index = 0;
                    rowNumber++;
                    continue;
                }
                result = System.Int32.TryParse(cursor.ToString(), out value);
                if(result) {
                    for(int i = 1; i <= value; i++) {
                        cells[rowNumber, index] = GetFigureType(cursor);
                        index++;
                    }
                } else {
                    cells[rowNumber, index] = GetFigureType(cursor);
                    index++;
                }
                counter++;
                cursor = Notation[counter];
            }
            return cells;
        }

        public static char GetFigureSymbol(Figure figure) {
            char temp = ' ';
            switch(figure.Type) {
                case FigureType.Rook: {
                        if(figure.Color == FigureColor.White) {
                            temp = 'R';
                            break;
                        } else {
                            temp = 'r';
                            break;
                        }
                    }
                case FigureType.Knight: {
                        if(figure.Color == FigureColor.White) {
                            temp = 'N';
                            break;
                        } else {
                            temp = 'n';
                            break;
                        }
                    }
                case FigureType.Bishop: {
                        if(figure.Color == FigureColor.White) {
                            temp = 'B';
                            break;
                        } else {
                            temp = 'b';
                            break;
                        }
                    }
                case FigureType.Queen: {
                        if(figure.Color == FigureColor.White) {
                            temp = 'Q';
                            break;
                        } else {
                            temp = 'q';
                            break;
                        }
                    }
                case FigureType.King: {
                        if(figure.Color == FigureColor.White) {
                            temp = 'K';
                            break;
                        } else {
                            temp = 'k';
                            break;
                        }
                    }
                case FigureType.Pawn: {
                        if(figure.Color == FigureColor.White) {
                            temp = 'P';
                            break;
                        } else {
                            temp = 'p';
                            break;
                        }
                    }
            }
            return temp;
        }

        public static Figure GetFigureType(char code) {
            Figure temp = new Figure();
            switch(code) {
                case 'P': {
                        temp.Color = FigureColor.White;
                        temp.Type = FigureType.Pawn;
                        break;
                    }
                case 'R': {
                        temp.Color = FigureColor.White;
                        temp.Type = FigureType.Rook;
                        break;
                    }
                case 'N': {
                        temp.Color = FigureColor.White;
                        temp.Type = FigureType.Knight;
                        break;
                    }
                case 'B': {
                        temp.Color = FigureColor.White;
                        temp.Type = FigureType.Bishop;
                        break;
                    }
                case 'K': {
                        temp.Color = FigureColor.White;
                        temp.Type = FigureType.King;
                        break;
                    }
                case 'Q': {
                        temp.Color = FigureColor.White;
                        temp.Type = FigureType.Queen;
                        break;
                    }

                case 'p': {
                        temp.Color = FigureColor.Black;
                        temp.Type = FigureType.Pawn;
                        break;
                    }
                case 'r': {
                        temp.Color = FigureColor.Black;
                        temp.Type = FigureType.Rook;
                        break;
                    }
                case 'n': {
                        temp.Color = FigureColor.Black;
                        temp.Type = FigureType.Knight;
                        break;
                    }
                case 'b': {
                        temp.Color = FigureColor.Black;
                        temp.Type = FigureType.Bishop;
                        break;
                    }
                case 'k': {
                        temp.Color = FigureColor.Black;
                        temp.Type = FigureType.King;
                        break;
                    }
                case 'q': {
                        temp.Color = FigureColor.Black;
                        temp.Type = FigureType.Queen;
                        break;
                    }
                default: {
                        temp.Color = FigureColor.Empty;
                        temp.Type = FigureType.Empty;
                        break;
                    }

            }
            return temp;
        }

        public static string CreateStateByModel(Figure[,] cells) {
            int row = 0;
            System.Text.StringBuilder temp = new System.Text.StringBuilder();
            for(int i = 0; i < 8; i++) {
                if(i != 0) {
                    temp.Append('/');
                }
                for(int j = 0; j < 8; j++) {
                    if(cells[i, j].Type != FigureType.Empty) {
                        if(row != 0) {
                            temp.Append(row.ToString());
                        }
                        row = 0;
                        temp.Append(GetFigureSymbol(cells[i, j]));
                    } else {
                        row++;
                    }
                    if(j == 7) {
                        if(row != 0) {
                            temp.Append(row.ToString());
                        }
                        row = 0;
                    };
                }
            }
            return temp.ToString() + " w KQkq - 0 1"; ///
        }

        public static int ConvertSymboltoInt(char symbol) {
            int temp = 0;
            switch(symbol) {
                case 'a': {
                        temp = 0;
                        break;
                    }
                case 'b': {
                        temp = 1;
                        break;
                    }
                case 'c': {
                        temp = 2;
                        break;
                    }
                case 'd': {
                        temp = 3;
                        break;
                    }
                case 'e': {
                        temp = 4;
                        break;
                    }
                case 'f': {
                        temp = 5;
                        break;
                    }
                case 'g': {
                        temp = 6;
                        break;
                    }
                case 'h': {
                        temp = 7;
                        break;
                    }

            }
            return temp;
        }

        public static void MakeMove(string move, Figure[,] cells) {
            string[] temp = move.Split(new Char[] { ' ' });
            string From = temp[0];
            string To = temp[1];
            int FromX = 7 - (Convert.ToInt32(From[1]) - 49);
            int FromY = ConvertSymboltoInt(From[0]);
            int ToX = 7 - (Convert.ToInt32(To[1]) - 49);
            int ToY = ConvertSymboltoInt(To[0]);
            Figure tempFigure = new Figure { Color = cells[FromX, FromY].Color, Type = cells[FromX, FromY].Type };
            cells[FromX, FromY].Color = FigureColor.Empty;
            cells[FromX, FromY].Type = FigureType.Empty;
            cells[ToX, ToY].Color = tempFigure.Color;
            cells[ToX, ToY].Type = tempFigure.Type;

        }

        public static FigureColor CheckColorOfCurrentPlayer(List<GameMove> moves){
            if(moves.Count % 2 == 1) return FigureColor.Black;
            else return FigureColor.White;
        }

        public static Enum MoveCheckCells(int FromX, int FromY, int ToX, int ToY, Figure[,] cells, FigureColor colorOfCurrentPlayer) {
            if(cells[FromX, FromY].Type == FigureType.Empty) return ResultMessage.NotHaveFigure;
            else if(cells[FromX, FromY].Color != colorOfCurrentPlayer) return ResultMessage.NotYourFigure;
            else return ResultMessage.GoodMove;
        }

        public static void RegisterMove(GameMove move, GameState gameState) {
            List<GameMove> currentMoves = new List<GameMove>(gameState.Moves);
            currentMoves.Add(move);
            gameState.Moves = currentMoves;

            Figure[,] cells = ChessOperations.Parse(gameState.GameStateNotation);

            ChessOperations.MakeMove(move.MoveNotation, cells);

            gameState.GameStateNotation = ChessOperations.CreateStateByModel(cells);
        }

    }
}
