using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChessClient.Models.Game
{
    public class Cell
    {
        public int number { get;set;}
        public char symbol { get; set; }
        public string figure = "";
    }
}