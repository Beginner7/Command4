using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessClient.Models
{
    public class GameModels
    {
        public string move { get; set; }


        public string[] ConvertMove(string move){
             string[] str= move.Split(new Char[] {' '});           
             return str;
        }


        public bool MakeMove(string move) {   
            return true;
        }
        
       

    }
}