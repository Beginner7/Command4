using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace ChessService.Models {
    //enum GameState {

    //}
    public abstract class Figure : ICloneable {
        int x;
        int y;
        readonly FigureColor color;
        public int[] Coordinate {
            get { return new int[] { x, y }; }
            set { x = value[0]; y = value[1]; }
        }
        public FigureColor Color { get { return color; } }

        public Figure(int x, int y, FigureColor color) {
            this.x = x;
            this.y = y;
            this.color = color;
        }
        public abstract object Clone();
        public bool IsIt(int x, int y) {
            return this.x == x && this.y == y;
        }
        public abstract List<int[]> GeneratePath(int x, int y);
        public abstract bool CanEat(Figure another);
        public abstract GameState CheckState(Figure another);
    }

    public class Pawn : Figure {
        public Pawn(int x, int y, FigureColor color)
            : base(x, y, color) {
        }
        public override object Clone() {
            return new Pawn(Coordinate[0], Coordinate[1], Color);
        }

        public override List<int[]> GeneratePath(int x, int y) {
            throw new NotImplementedException();
        }

        public override bool CanEat(Figure another) {
            throw new NotImplementedException();
        }

        public override GameState CheckState(Figure another) {
            throw new NotImplementedException();
        }
    }
}