using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChessClient.Models.Game;
using Common;

namespace ChessClient.Models
{
    public enum FigureColor { White, Black }
    public enum FigureType { Pawn, Rook, Knight }
    public struct Figure{
        FigureColor Color;
        FigureType Type;
    }

    public class GameModels
    {
        Figure[,] cells = new Figure[8, 8];
        GameState gameState;
        public GameModels(GameState gameState)
        {
            this.gameState = gameState;
            Parse(gameState.GameStateNotation);
        }

        void Parse(string p)
        {
            
        }
        public Figure GetCellInfo(int x, int y)
        {
            return new Figure();
        }
        public string GetFigureImage(int x, int y)
        {
           
            return string.Empty;
        }

        
    
        public string[,] desk = new string[8, 8]
          {{"rookwhite.png","knightwhite.png","bishopwhite.png","queenwhite.png","kingwhite.png","bishopwhite.png","knightwhite.png","rookwhite.png"},
           {"pawnwhite.png","pawnwhite.png","pawnwhite.png","pawnwhite.png","pawnwhite.png","pawnwhite.png","pawnwhite.png","pawnwhite.png"},
           {"","","","","","","",""},
           {"","","","","","","",""},
           {"","","","","","","",""},
           {"","","","","","","",""},
           {"pawnblack.png","pawnblack.png","pawnblack.png","pawnblack.png","pawnblack.png","pawnblack.png","pawnblack.png","pawnblack.png"},
           {"rookblack.png","knightblack.png","bishopblack.png","queenblack.png","kingblack.png","bishopblack.png","knightblack.png","rookblack.png"}
          };
        public string move { get; set; }


        public string[] ConvertMove(string move){
             string[] str= move.Split(new Char[] {' '});
             From = str[0];
             To = str[1];
             return str;
        }


        public bool MakeMove(string move) {   
            return true;
        }

        public void NewMove() { 
            
        }

        public Cellij ConvertCell(string cell)
        {
            Cellij cellij = new Cellij();

            return cellij;
        
        }
        
        private string From;
        private string To;
        public struct Cellij{
            int i;
            int j;
        }

    }
}