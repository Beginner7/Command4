using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    [DataContract]
    public class GameMove {
        [DataMember]
        public string MoveNotation { get; set; }

        public int[] MoveParse() {
        string[] temp = MoveNotation.Split(new Char[] { ' ' });
        string From = temp[0];
        string To = temp[1];
        
        int FromX = 7 - (Convert.ToInt32(From[1]) - 49);
        int FromY = ConvertSymboltoInt(From[0]);
        int ToX = 7 - (Convert.ToInt32(To[1]) - 49);
        int ToY = ConvertSymboltoInt(To[0]);

        return new int[] { FromX, FromY, ToX, ToY };
        }
        public static int ConvertSymboltoInt(char symbol) {
            int temp = 0;
            switch(symbol) {
                case 'a': {
                        temp = 0;
                        break;
                    }
                case 'b': {
                        temp = 1;
                        break;
                    }
                case 'c': {
                        temp = 2;
                        break;
                    }
                case 'd': {
                        temp = 3;
                        break;
                    }
                case 'e': {
                        temp = 4;
                        break;
                    }
                case 'f': {
                        temp = 5;
                        break;
                    }
                case 'g': {
                        temp = 6;
                        break;
                    }
                case 'h': {
                        temp = 7;
                        break;
                    }

            }
            return temp;
        }
    }
}
