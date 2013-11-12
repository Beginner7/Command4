using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChessClient.Models.Game;
using Common;

namespace ChessClient.Models
{
    public enum FigureColor { White, Black, Empty }
    public enum FigureType  { Pawn, Rook, Knight, Bishop, Queen, King, Empty }
    public struct Figure{
        public FigureColor Color;
        public FigureType Type;
    }

    public class GameModels
    {
        public Figure[,] cells = new Figure[8, 8];
        GameState gameState;
        
        public GameModels(GameState gameState)
        {
            this.gameState = gameState;
            Parse(gameState.GameStateNotation);
        }

        void Parse(string p)
        {
            const char EOLN='\n'; 
            int  counter=0, rowNumber=0, value=0;
            char cursor=p[0];
            bool result=false;
            while (cursor!=' ') {
                result=System.Int32.TryParse(cursor.ToString(),out value);
                if (result) {
                    for (int i=1;i<=value;i++) {
                        GetFigureType(cursor);
                    }
                    counter+=value;
                    cursor=p[counter];
                }
                else { 
                    cells[rowNumber,cursor]=GetFigureType(cursor);
                    counter++;
                    cursor=p[counter];
                }
            }
        }

        public Figure GetCellInfo(int x, int y) {
            return new Figure();
        }

        public string GetFigureImage(int x, int y) {
           
            return string.Empty;
        }

        private Figure GetFigureType(char code) {
            Figure temp=new Figure();
            switch (code) {
                case 'P': {
                    temp.Color=FigureColor.Black;
                    temp.Type=FigureType.Pawn;
                    break;
                }
                case 'R' : {
                       temp.Color=FigureColor.Black;
                       temp.Type=FigureType.Rook;
                       break;
                }
                case 'N' : {
                       temp.Color=FigureColor.Black;
                       temp.Type=FigureType.Knight;
                       break;
                }
                case 'B' : {
                       temp.Color=FigureColor.Black;
                       temp.Type=FigureType.Bishop;
                       break;
                }
                case 'K' : {
                      temp.Color=FigureColor.Black;
                      temp.Type=FigureType.King;
                      break;
                }
                case 'Q' : {
                      temp.Color=FigureColor.Black;
                      temp.Type=FigureType.Queen;
                      break;
                }
                case 'p': {
                    temp.Color=FigureColor.White;
                    temp.Type=FigureType.Pawn;
                    break;
                }
                case 'r' : {
                       temp.Color=FigureColor.White;
                       temp.Type=FigureType.Rook;
                       break;
                }
                case 'n' : {
                       temp.Color=FigureColor.White;
                       temp.Type=FigureType.Knight;
                       break;
                }
                case 'b' : {
                       temp.Color=FigureColor.White;
                       temp.Type=FigureType.Bishop;
                       break;
                }
                case 'k' : {
                      temp.Color=FigureColor.White;
                      temp.Type=FigureType.King;
                      break;
                }
                case 'q' : {
                      temp.Color=FigureColor.White;
                      temp.Type=FigureType.Queen;
                      break;
                }
                default:
                    {
                        temp.Color = FigureColor.Empty;
                        temp.Type = FigureType.Empty;
                        break;
                    }
            }
            return temp;
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
             //From = str[0];
             //To = str[1];
             return str;
        }

    }
}