using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace ChessClient.Models
{

    public class GameModel
    {
        public Figure[,] cells = new Figure[8, 8];
        public GameState gameState;
        
        public GameModel(GameState gamestate)
        {
            
            this.gameState = gamestate;
            ChessOperations.Parse(gameState.GameStateNotation, cells);
        }

        

                    


        public string GetFigureImage(int x, int y) {
            if (cells[x, y].Type != FigureType.Empty)
            {
                string str = "images/" + cells[x, y].Type + cells[x, y].Color + ".png";
                return str;
            }
            else { 
                string str = "";
                return str; 
            }
        }
        


        public string move { get; set; }

        



    }
}