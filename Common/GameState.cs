using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    [DataContract]
    public class GameState {
        [DataMember]
        public string GameStateNotation { get; set; }
        [DataMember]
        public Guid GameId { get; set; }
        [DataMember]
        public Guid WhiteGamer { get; set; }
        [DataMember]
        public Guid BlackGamer { get; set; }
        [DataMember]
        public IEnumerable<GameMove> Moves { get; set; }

        public GameState() {
            this.GameStateNotation = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            this.Moves = new List<GameMove>();
            //"2QR1B2/rpb2p1q/p7/2PBk1P1/p3N2r/2Ppn1P1/KN2b3/4R3 w KQkq - 0 1"
        }
        public void RegisterMove(GameMove move) {
            List<GameMove> currentMoves = new List<GameMove>(Moves);
            currentMoves.Add(move);
            Moves = currentMoves;

            Figure[,] cells = ChessOperations.Parse(GameStateNotation);

            ChessOperations.MakeMove(move.MoveNotation, cells);

            GameStateNotation = ChessOperations.CreateStateByModel(cells);
        }
    }
}






