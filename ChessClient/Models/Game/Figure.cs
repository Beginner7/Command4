using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;


namespace ChessClient.Models.Game
{
    public class Figure
    {
        public ChessDesk.ChessColor color { get; private set; }
        public FigureType type { get; set; }
        public char symbol { get; private set; }
        public ChessDesk.CellNumber currentCell { get; set; }

        public Figure(FigureType type, ChessDesk.ChessColor color, int col, int row)
        {
            ChessDesk.CellNumber temp;
            this.color = color;
            this.type = type;
            temp.col = col;
            temp.row = row;
            this.currentCell = temp;
            switch (type)
            {
                case FigureType.Rook: 
                    {
                        this.symbol = 'r';
                        break;
                    }
                case FigureType.Queen:
                    {
                        this.symbol = 'q';
                        break;
                    }
                case FigureType.King:
                    {
                        this.symbol = 'k';
                        break;
                    }
                case FigureType.Bishop: 
                    {
                        this.symbol = 'b';
                        break;
                    }
                case FigureType.Knight:
                    {
                        this.symbol = 'n';
                        break;
                    }
                case FigureType.Pawn: 
                    {
                        this.symbol = 'p';
                        break;
                    }
                default: {
                        this.symbol = ' ';
                        break;
                    }
            }
            switch (color)
            {
                case ChessDesk.ChessColor.White:
                    {
                        this.symbol = char.ToUpper(this.symbol);
                        break;
                    }
                case ChessDesk.ChessColor.Black:
                    {
                        this.symbol = char.ToLower(this.symbol);
                        break;
                    }
                default:
                    {
                        this.symbol = ' ';
                        break;
                    }
            }
        }

    }
}