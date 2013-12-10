using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace ChessClient.Models {
    public struct Figure {
        public FigureColor Color;
        public FigureType Type;
    }
    public class GameModel {
        public struct CoordinateXY {
            public int x;
            public int y;
        }
        public Figure[,] cells;
        public string[,] cellsCss;
        public GameState gameState;
        public bool CurrentPlayerWhite;
        public string move { get; set; }
        public List<CoordinateXY> CurrentMoves;
        public CoordinateXY CurrentFigure;

        public GameModel(GameState gamestate) {

            this.gameState = gamestate;
            this.cells = Parse(gameState.GameStateNotation);
            this.CurrentMoves = new List<CoordinateXY>();
            if(gameState.Moves.Count() % 2 == 0) {
                this.CurrentPlayerWhite = false;
            } else {
                this.CurrentPlayerWhite = true;
        }
            CssClass();
        }

        public void CssClass() {
            this.cellsCss = new string[8, 8];
            int tempcolor = 1;
            CoordinateXY tempXY;
            for(int i = 0; i < 8; i++) {
                for(int j = 0; j < 8; j++) {
                    if(tempcolor % 2 == 0) {
                        cellsCss[i, j] = "blackCell";
                    } else {
                        cellsCss[i, j] = "whiteCell";
                    }
                    tempXY.x = i; tempXY.y = j;
                    foreach(CoordinateXY temp in CurrentMoves) {
                        if(temp.Equals(tempXY)) {
                            cellsCss[i, j] = "currentCell";
                            break;
                        }
                    }
                    if(j != 7) tempcolor++;


                }

            }
        }

        public bool IsWhiteFigure(int x, int y) {
            if(cells[x, y].Color != FigureColor.White) {
                return true;
            } else {
                return false;
            }
        }

        public bool IsBlackFigure(int x, int y) {
            if(cells[x, y].Color != FigureColor.Black) {
                return true;
            } else {
                return false;
            }
        }

        public string GetFigureImage(int x, int y) {
            if(cells[x, y].Type != FigureType.Empty) {
                string str = "" + cells[x, y].Type + cells[x, y].Color;
                return str;
            } else {
                string str = "NoneText";
                return str;
            }
        }

        public List<CoordinateXY> pawnBlackMove(int x, int y) {
            List<CoordinateXY> list = new List<CoordinateXY>();
            CoordinateXY coordinateXY;
            if((x + 1) <= 7 && (y + 1) <= 7) {
                if(cells[x + 1, y + 1].Color == FigureColor.White) {
                coordinateXY.x = x + 1;
                coordinateXY.y = y + 1;
                list.Add(coordinateXY);
            }
            }
            if((x + 1) <= 7 && (y - 1) >= 0) {
                if(cells[x + 1, y - 1].Color == FigureColor.White) {
                coordinateXY.x = x + 1;
                coordinateXY.y = y - 1;
                list.Add(coordinateXY);
            }
            }
            if((x + 1) <= 7) {
                if(cells[x + 1, y].Type == FigureType.Empty) {
                    coordinateXY.x = x + 1;
                    coordinateXY.y = y;
                    list.Add(coordinateXY);
                    if(x == 1 && cells[x + 2, y].Type == FigureType.Empty) {
                coordinateXY.x = x + 2;
                coordinateXY.y = y;
                list.Add(coordinateXY);
            }
                }
            }
            return list;

        }

        public List<CoordinateXY> pawnWhiteMove(int x, int y) {
            List<CoordinateXY> list = new List<CoordinateXY>();
            CoordinateXY coordinateXY;
            if((x - 1) >= 0 && (y + 1) <= 7) {
                if(cells[x - 1, y + 1].Color == FigureColor.Black) {
                coordinateXY.x = x - 1;
                coordinateXY.y = y + 1;
                list.Add(coordinateXY);
            }
            }
            if((x - 1) >= 0 && (y - 1) >= 0) {
                if(cells[x - 1, y - 1].Color == FigureColor.Black) {
                coordinateXY.x = x - 1;
                coordinateXY.y = y - 1;
                list.Add(coordinateXY);
            }
            }
            if((x - 1) >= 0) {
                if(cells[x - 1, y].Type == FigureType.Empty) {
                    coordinateXY.x = x - 1;
                    coordinateXY.y = y;
                    list.Add(coordinateXY);
                    if(x == 6 && cells[x - 2, y].Type == FigureType.Empty) {
                coordinateXY.x = x - 2;
                coordinateXY.y = y;
                list.Add(coordinateXY);
            }
                }
            }
            return list;
        }

        public List<CoordinateXY> knightMove(int x, int y) {
            FigureColor color = cells[x, y].Color;
            CoordinateXY[] travel = new CoordinateXY[]{
                new CoordinateXY{x = -2, y = -1},
                new CoordinateXY{x = -2, y = 1},
                new CoordinateXY{x = 1, y = -2},
                new CoordinateXY{x = -1, y = -2},
                new CoordinateXY{x = 1, y = 2},
                new CoordinateXY{x = -1, y = 2},
                new CoordinateXY{x = 2, y = -1},
                new CoordinateXY{x = 2, y = 1}
            };
            List<CoordinateXY> list = new List<CoordinateXY>();
            CoordinateXY coordinateXY;
            foreach(CoordinateXY elem in travel) {
                int xtemp = x + elem.x;
                int ytemp = y + elem.y;
                if(xtemp >= 0 && xtemp <= 7 && ytemp >= 0 && ytemp <= 7 && cells[xtemp, ytemp].Color != color) {
                    coordinateXY.x = xtemp;
                    coordinateXY.y = ytemp;
                    list.Add(coordinateXY);
                }

            }
            return list;
        }


        public List<CoordinateXY> kingMove(int x, int y) { //checkmate
            FigureColor color = cells[x, y].Color;
            CoordinateXY[] travel = new CoordinateXY[]{
                 new CoordinateXY{x = -1, y = 0},
                 new CoordinateXY{x = -1, y = 1},
                 new CoordinateXY{x = -1, y = -1},
                 new CoordinateXY{x = 0, y = -1},
                 new CoordinateXY{x = 0, y = 1},
                 new CoordinateXY{x = 1, y = 1},
                 new CoordinateXY{x = 1, y = 0},
                 new CoordinateXY{x = 1, y = -1}
            };
            CoordinateXY coordinateXY;
            List<CoordinateXY> list = new List<CoordinateXY>();
            foreach(CoordinateXY elem in travel) {
                int xtemp = x + elem.x;
                int ytemp = y + elem.y;
                if(xtemp >= 0 && xtemp <= 7 && ytemp >= 0 && ytemp <= 7 && cells[xtemp, ytemp].Color != color) {
                    coordinateXY.x = xtemp;
                    coordinateXY.y = ytemp;
                    list.Add(coordinateXY);
                }

            }
            return list;
        }


        public List<CoordinateXY> rookMove(int x, int y) {
            FigureColor color = cells[x, y].Color;
            List<CoordinateXY> list = new List<CoordinateXY>();
            CoordinateXY travel;
            int i = x - 1;
            while(i >= 0) {
                if(cells[i, y].Color == color) {
                    break;
                }
                if(cells[i, y].Color != FigureColor.Empty) {
                    travel.x = i;
                    travel.y = y;
                    list.Add(travel);
                    break;
                }
                travel.x = i;
                travel.y = y;
                list.Add(travel);
                i--;
            };
            i = x + 1;
            while(i <= 7) {
                if(cells[i, y].Color == color) {
                    break;
                }
                if(cells[i, y].Color != FigureColor.Empty) {
                    travel.x = i;
                    travel.y = y;
                    list.Add(travel);
                    break;
                }
                travel.x = i;
                travel.y = y;
                list.Add(travel);
                i++;
            };
            i = y - 1;
            while(i >= 0) {
                if(cells[x, i].Color == color) {
                    break;
                }
                if(cells[x, i].Color != FigureColor.Empty) {
                    travel.x = x;
                    travel.y = i;
                    list.Add(travel);
                    break;
                }
                travel.x = x;
                travel.y = i;
                list.Add(travel);
                i--;
            };
            i = y + 1;
            while(i <= 7) {
                if(cells[x, i].Color == color) {
                    break;
                }
                if(cells[x, i].Color != FigureColor.Empty) {
                    travel.x = x;
                    travel.y = i;
                    list.Add(travel);
                    break;
                }
                travel.x = x;
                travel.y = i;
                list.Add(travel);
                i++;
            };
            return list;
        }


        public List<CoordinateXY> bishopMove(int x, int y) {
            FigureColor color = cells[x, y].Color;
            List<CoordinateXY> list = new List<CoordinateXY>();
            CoordinateXY travel;
            int i = x - 1;
            int j = y - 1;
            while(i >= 0 && j >= 0) {
                if(cells[i, j].Color == color) {
                    break;
                }
                if(cells[i, j].Color != FigureColor.Empty) {
                    travel.x = i;
                    travel.y = j;
                    list.Add(travel);
                    break;
                }
                travel.x = i;
                travel.y = j;
                list.Add(travel);
                i--; j--;
            };
            i = x + 1;
            j = y + 1;
            while(i <= 7 && j <= 7) {
                if(cells[i, j].Color == color) {
                    break;
                }
                if(cells[i, j].Color != FigureColor.Empty) {
                    travel.x = i;
                    travel.y = j;
                    list.Add(travel);
                    break;
                }
                travel.x = i;
                travel.y = j;
                list.Add(travel);
                i++; j++;
            };
            i = x + 1;
            j = y - 1;
            while(i <= 7 && j >= 0) {
                if(cells[i, j].Color == color) {
                    break;
                }
                if(cells[i, j].Color != FigureColor.Empty) {
                    travel.x = i;
                    travel.y = j;
                    list.Add(travel);
                    break;
                }
                travel.x = i;
                travel.y = j;
                list.Add(travel);
                i++;
                j--;
            };
            i = x - 1;
            j = y + 1;
            while(i >= 0 && j <= 7) {
                if(cells[i, j].Color == color) {
                    break;
                }
                if(cells[i, j].Color != FigureColor.Empty) {
                    travel.x = i;
                    travel.y = j;
                    list.Add(travel);
                    break;
                }
                travel.x = i;
                travel.y = j;
                list.Add(travel);
                i--;
                j++;
            };
            return list;
        }

        public List<CoordinateXY> queenMove(int x, int y) {
            FigureColor color = cells[x, y].Color;
            List<CoordinateXY> list = new List<CoordinateXY>();
            CoordinateXY travel;
            int i = x - 1;
            while(i >= 0) {
                if(cells[i, y].Color == color) {
                    break;
                }
                if(cells[i, y].Color != FigureColor.Empty) {
                    travel.x = i;
                    travel.y = y;
                    list.Add(travel);
                    break;
                }
                travel.x = i;
                travel.y = y;
                list.Add(travel);
                i--;
            };
            i = x + 1;
            while(i <= 7) {
                if(cells[i, y].Color == color) {
                    break;
                }
                if(cells[i, y].Color != FigureColor.Empty) {
                    travel.x = i;
                    travel.y = y;
                    list.Add(travel);
                    break;
                }
                travel.x = i;
                travel.y = y;
                list.Add(travel);
                i++;
            };
            i = y - 1;
            while(i >= 0) {
                if(cells[x, i].Color == color) {
                    break;
                }
                if(cells[x, i].Color != FigureColor.Empty) {
                    travel.x = x;
                    travel.y = i;
                    list.Add(travel);
                    break;
                }
                travel.x = x;
                travel.y = i;
                list.Add(travel);
                i--;
            };
            i = y + 1;
            while(i <= 7) {
                if(cells[x, i].Color == color) {
                    break;
                }
                if(cells[x, i].Color != FigureColor.Empty) {
                    travel.x = x;
                    travel.y = i;
                    list.Add(travel);
                    break;
                }
                travel.x = x;
                travel.y = i;
                list.Add(travel);
                i++;
            };
            i = x - 1;
            int j = y - 1;
            while(i >= 0 && j >= 0) {
                if(cells[i, j].Color == color) {
                    break;
                }
                if(cells[i, j].Color != FigureColor.Empty) {
                    travel.x = i;
                    travel.y = j;
                    list.Add(travel);
                    break;
                }
                travel.x = i;
                travel.y = j;
                list.Add(travel);
                i--; j--;
            };
            i = x + 1;
            j = y + 1;
            while(i <= 7 && j <= 7) {
                if(cells[i, j].Color == color) {
                    break;
                }
                if(cells[i, j].Color != FigureColor.Empty) {
                    travel.x = i;
                    travel.y = j;
                    list.Add(travel);
                    break;
                }
                travel.x = i;
                travel.y = j;
                list.Add(travel);
                i++; j++;
            };
            i = x + 1;
            j = y - 1;
            while(i <= 7 && j >= 0) {
                if(cells[i, j].Color == color) {
                    break;
                }
                if(cells[i, j].Color != FigureColor.Empty) {
                    travel.x = i;
                    travel.y = j;
                    list.Add(travel);
                    break;
                }
                travel.x = i;
                travel.y = j;
                list.Add(travel);
                i++;
                j--;
            };
            i = x - 1;
            j = y + 1;
            while(i >= 0 && j <= 7) {
                if(cells[i, j].Color == color) {
                    break;
                }
                if(cells[i, j].Color != FigureColor.Empty) {
                    travel.x = i;
                    travel.y = j;
                    list.Add(travel);
                    break;
                }
                travel.x = i;
                travel.y = j;
                list.Add(travel);
                i--;
                j++;
            };
            return list;
        }


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
    }
}