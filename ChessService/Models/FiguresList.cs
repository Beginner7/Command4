using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace ChessService.Models {
    public enum CurrentGameResult {
        Ok,
        BarrierInThePath,
        YourFigureInCellTo
    }
    public abstract class Figure : ICloneable {
        int x;
        int y;
        readonly FigureColor color;
        public int[] Coordinate {
            get { return new int[] { x, y }; }
            set { x = value[0]; y = value[1]; }
        }
        public FigureColor Color { get { return color; } }
        public abstract string Notation { get; }

        public Figure(int x, int y, FigureColor color) {
            this.Coordinate[0] = x;
            this.Coordinate[1] = y;
            this.color = color;
        }
        public abstract object Clone();
        public bool IsIt(int x, int y) {
            return this.Coordinate[0] == x && this.Coordinate[1] == y;
        }
        public abstract List<int[]> GeneratePath(int x, int y);
        public virtual bool CanEat(Figure another) {
            if(another.Color != this.Color) return true;
            else return false;
        }
        public virtual CurrentGameResult CheckState(Figure another) {
            return CurrentGameResult.Ok;
        }
    }

    public class Pawn : Figure {
        public Pawn(int x, int y, FigureColor color)
            : base(x, y, color) {
        }
        public override object Clone() {
            return new Pawn(Coordinate[0], Coordinate[1], Color);
        }

        public override string Notation {
            get { return Color == FigureColor.White ? "p" : "P"; }
        }
        public override List<int[]> GeneratePath(int x, int y) {
            int moveX = x - this.Coordinate[0], moveY = y - this.Coordinate[1], currentX, currentY = this.Coordinate[1];
            List<int[]> path = new List<int[]>();

            if(moveX > 0) {
                currentX = this.Coordinate[0] + 1; currentY = this.Coordinate[1] + 1;
                while(currentX <= x) {
                    path.Add(new int[] { currentX, currentY });
                    currentX++; currentY++;
                }
            } else if(moveX < 0) {
                currentX = this.Coordinate[0] - 1; currentY = this.Coordinate[1] + 1;
                while(currentX >= x) {
                    path.Add(new int[] { currentX, currentY });
                    currentX--; currentY++;
                }
            } else {
                for(int i = currentY + 1; i <= y; i++) {
                    path.Add(new int[] { this.Coordinate[0], i });
                }
            }

            return path;
        }
    }

    public class Rook : Figure {
        public Rook(int x, int y, FigureColor color)
            : base(x, y, color) {
        }
        public override object Clone() {
            return new Rook(Coordinate[0], Coordinate[1], Color);
        }
        public override string Notation {
            get { return Color == FigureColor.White ? "r" : "R"; }
        }
        public override List<int[]> GeneratePath(int x, int y) {
            int moveX = x - this.Coordinate[0], moveY = y - this.Coordinate[1], currentX=this.Coordinate[0], currentY = this.Coordinate[1];
            List<int[]> path = new List<int[]>();

            if(moveX != 0) {
                if(moveX > 0) {
                    for(currentX = this.Coordinate[0]+1; currentX <= x; currentX++) {
                        path.Add(new int[] { currentX, currentY });
                    }
                } else {
                    for(currentX = this.Coordinate[0]-1; currentX >= x; currentX--) {
                        path.Add(new int[] { currentX, currentY });
                    }
                }
            } else {
                if(moveY > 0) {
                    for(currentY=this.Coordinate[1]+1; currentY <= y; currentY++) {
                        path.Add(new int[] { currentX, currentY });
                    }
                } else {
                    for(currentY = this.Coordinate[1] - 1; currentY >= y; currentY--) {
                        path.Add(new int[] { currentX, currentY });
                    }
                }
            }

            return path;
        }
    }

    public class Knight : Figure {
        public Knight(int x, int y, FigureColor color)
            : base(x, y, color) {
        }
        public override object Clone() {
            return new Knight(Coordinate[0], Coordinate[1], Color);
        }
        public override string Notation {
            get { return Color == FigureColor.White ? "n" : "N"; }
        }
        public override List<int[]> GeneratePath(int x, int y) {
            int moveX = x - this.Coordinate[0], moveY = y - this.Coordinate[1];
            List<int[]> path = new List<int[]>();

                    path.Add(new int[] { this.Coordinate[0], this.Coordinate[1] });

            return path;
        }
        public override CurrentGameResult CheckState(Figure another) {
            throw new NotImplementedException();
        }
    }

    public class Bishop : Figure {
        public Bishop(int x, int y, FigureColor color)
            : base(x, y, color) {
        }
        public override object Clone() {
            return new Bishop(Coordinate[0], Coordinate[1], Color);
        }
        public override string Notation {
            get { return Color == FigureColor.White ? "b" : "B"; }
        }
        public override List<int[]> GeneratePath(int x, int y) {
            int moveX = x - this.Coordinate[0], moveY = y - this.Coordinate[1], currentX, currentY = this.Coordinate[1];
            List<int[]> path = new List<int[]>();

            if(moveX > 0) {
                if(moveY > 0) {
                    currentX=this.Coordinate[0]+1; currentY=this.Coordinate[1]+1;
                    while(currentX <= x) {
                        path.Add(new int[] { currentX, currentY });
                        currentX++; currentY++;
                    }                 
                } else {
                    currentX = this.Coordinate[0] + 1; currentY = this.Coordinate[1] - 1;
                    while(currentX <= x) {
                        path.Add(new int[] { currentX, currentY });
                        currentX++; currentY--;
                    }
                }
            } else {
                if(moveY > 0) {
                    currentX = this.Coordinate[0] - 1; currentY = this.Coordinate[1] + 1;
                    while(currentX >= x) {
                        path.Add(new int[] { currentX, currentY });
                        currentX--; currentY++;
                    }
                } else {
                    currentX = this.Coordinate[0] - 1; currentY = this.Coordinate[1] - 1;
                    while(currentX >= x) {
                        path.Add(new int[] { currentX, currentY });
                        currentX--; currentY--;
                    }
                }
            }

            return path;
        }
        public override CurrentGameResult CheckState(Figure another) {
            throw new NotImplementedException();
        }
    }

    public class King : Figure {
        public King(int x, int y, FigureColor color)
            : base(x, y, color) {
        }
        public override object Clone() {
            return new King(Coordinate[0], Coordinate[1], Color);
        }
        public override string Notation {
            get { return Color == FigureColor.White ? "k" : "K"; }
        }
        public override List<int[]> GeneratePath(int x, int y) {
            int moveX = x - this.Coordinate[0], moveY = y - this.Coordinate[1], currentX=this.Coordinate[0], currentY = this.Coordinate[1];
            List<int[]> path = new List<int[]>();

            if(moveX > 0) currentX++;
            else if(moveX<0) currentX--;

            if(moveY > 0) currentY++;
            else if(moveY < 0) currentY--;

            path.Add(new int[] { currentX, currentY });
            return path;
        }
        public override CurrentGameResult CheckState(Figure another) {
            throw new NotImplementedException();
        }
    }

    public class Queen : Figure {
        public Queen(int x, int y, FigureColor color)
            : base(x, y, color) {
        }
        public override object Clone() {
            return new Queen(Coordinate[0], Coordinate[1], Color);
        }
        public override string Notation {
            get { return Color == FigureColor.White ? "q" : "Q"; }
        }
        public override List<int[]> GeneratePath(int x, int y) {
            int moveX = x - this.Coordinate[0], moveY = y - this.Coordinate[1], currentX=this.Coordinate[0], currentY = this.Coordinate[1];
            List<int[]> path = new List<int[]>();


            if(moveX > 0) {
                if(moveY > 0) {
                    currentX++; currentY++;
                    while(currentX <= x) {
                        path.Add(new int[] { currentX, currentY });
                        currentX++; currentY++;
                    }  
                    path.Add(new int[] { currentX, currentY });
                } else if(moveY == 0) {
                    currentX++;
                    while(currentX <= x) {
                        path.Add(new int[] { currentX, currentY });
                        currentX++;
                    }
                } else {
                    currentX++; currentY--;
                    while(currentX <= x) {
                        path.Add(new int[] { currentX, currentY });
                        currentX++; currentY--;
                    }
                }
            } else if(moveX == 0) {
                if(moveY > 0) {
                    currentY++;
                    while(currentY <= y) {
                        path.Add(new int[] { currentX, currentY });
                        currentY++;
                    }
                } else {
                    currentY--;
                    while(currentY >= y) {
                        path.Add(new int[] { currentX, currentY });
                        currentY--;
                    }
                }
            } else {
                if(moveY > 0) {
                    currentX--; currentY++;
                    while(currentX >= x) {
                        path.Add(new int[] { currentX, currentY });
                        currentX--; currentY++;
                    }
                } else if(moveY == 0) {
                    currentX--;
                    while(currentX >= x) {
                        path.Add(new int[] { currentX, currentY });
                        currentX--;
                    }
                } else {
                    currentX--; currentY--;
                    while(currentX >= x) {
                        path.Add(new int[] { currentX, currentY });
                        currentX--; currentY--;
                    }
                }
            }

            return path;
        }

        public override CurrentGameResult CheckState(Figure another) {
            throw new NotImplementedException();
        }
    }
}