using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace ChessClient.Models {

    public class GameModel {
        public Figure[,] cells;
        public GameState gameState;
        struct CoordinateXY {
            public int x;
            public int y;
        }

        public GameModel(GameState gamestate) {

            this.gameState = gamestate;
            this.cells=ChessOperations.Parse(gameState.GameStateNotation);
        }

        public string GetFigureImage(int x, int y) {
            if(cells[x, y].Type != FigureType.Empty) {
                string str = "images/" + cells[x, y].Type + cells[x, y].Color + ".png";
                return str;
            } else {
                string str = "";
                return str;
            }
        }

        public string move { get; set; }

        List<CoordinateXY> pawnBlackMove(int x, int y) { 
            List<CoordinateXY> list = new List<CoordinateXY>();
            CoordinateXY coordinateXY;
            if(cells[x + 1, y + 1].Color == FigureColor.Black) {
                coordinateXY.x = x + 1;
                coordinateXY.y = y + 1;
                list.Add(coordinateXY);
            }
            if(cells[x + 1, y - 1].Color == FigureColor.Black) {
                coordinateXY.x = x + 1;
                coordinateXY.y = y - 1;
                list.Add(coordinateXY);
            }
            if(x == 1) {
                coordinateXY.x = x + 2;
                coordinateXY.y = y;
                list.Add(coordinateXY);
            }
            coordinateXY.x = x + 1;
            coordinateXY.y = y;
            list.Add(coordinateXY);
            return list;

        }

        List<CoordinateXY> pawnWhiteMove(int x, int y) {
            List<CoordinateXY> list = new List<CoordinateXY>();
            CoordinateXY coordinateXY;
            if(cells[x + 1, y + 1].Color == FigureColor.White) {
                coordinateXY.x = x - 1;
                coordinateXY.y = y + 1;
                list.Add(coordinateXY);
            }
            if(cells[x + 1, y - 1].Color == FigureColor.White) {
                coordinateXY.x = x - 1;
                coordinateXY.y = y - 1;
                list.Add(coordinateXY);
            }
            if(x == 1) {
                coordinateXY.x = x - 2;
                coordinateXY.y = y;
                list.Add(coordinateXY);
            }
            coordinateXY.x = x - 1;
            coordinateXY.y = y;
            list.Add(coordinateXY);
            return list;
        }

        List<CoordinateXY> knightMove(int x, int y) {
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
            foreach(CoordinateXY elem in travel) {
                int xtemp = x + elem.x;
                int ytemp = y + elem.y;
                if(xtemp >= 0 && xtemp <= 7 && ytemp >= 0 && ytemp <= 7 && cells[xtemp,ytemp].Color != color) {
                    list.Add(elem);
                }

            }
            return list;
        }


        List<CoordinateXY> kingMove(int x, int y) { //checkmate
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
            List<CoordinateXY> list = new List<CoordinateXY>();
            foreach(CoordinateXY elem in travel) {
                int xtemp = x + elem.x;
                int ytemp = y + elem.y;
                if(xtemp >= 0 && xtemp <= 7 && ytemp >= 0 && ytemp <= 7 && cells[xtemp, ytemp].Color != color) {
                    list.Add(elem);
                }

            }
            return list;
        }

        List<CoordinateXY> rookMove(int x, int y) {
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


        List<CoordinateXY> bishopMove(int x, int y) {
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
            while(i <= 0 && j >= 7) {
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

        List<CoordinateXY> queenMove(int x, int y) {
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
            while(i <= 0 && j >= 7) {
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

    }
}