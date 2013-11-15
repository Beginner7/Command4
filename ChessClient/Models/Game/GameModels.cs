using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            const char EOLN=' '; 
            int  counter=0, rowNumber=0, value=0, index=0;
            char cursor=p[0];
            bool result=false;
            while (cursor!=EOLN) {
                if (cursor == '/')
                {
                    counter++;
                    cursor = p[counter];
                    index = 0;
                    rowNumber++;
                    continue;
                }
                result=System.Int32.TryParse(cursor.ToString(),out value);
                if (result) {
                    for (int i=1;i<=value;i++) {
                        cells[rowNumber, index] = GetFigureType(cursor);
                        index++;
                    }
                }
                else { 
                    cells[rowNumber, index]=GetFigureType(cursor);
                    index++;
                }
                    counter++;
                    cursor=p[counter];
            }
        }

        public string CreateStateByModel() {
            int row=0;
            System.Text.StringBuilder temp = new System.Text.StringBuilder();
            for (int i=0;i<8;i++) {
                for (int j=0;j<8;j++) {
                    if (cells[i,j].Type!=FigureType.Empty) {
                       if (row!=0) {
                           temp.Append(row.ToString());
                       }
                        row = 0;
                        //TODO: Get figure's symbol
                    }
                    else {
                        row++;
                    }
                    if (j == 7) { row = 0; };
                }
            }
            return temp.ToString();
        }




                        


        public Figure GetCellInfo(int x, int y) {
            Figure temp = new Figure();
            temp=cells[x,y];
            return temp;
        }

        public string GetFigureImage(int x, int y) {
            string str = "images/" + cells[x, y].Type + cells[x, y].Color + ".png"; 
            return str;
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
                
            }
            return temp;
        }


        public string move { get; set; }


        public string[] ConvertMove(string move){
             string[] str= move.Split(new Char[] {' '});
             //From = str[0];
             //To = str[1];
             return str;
        }

    }
}