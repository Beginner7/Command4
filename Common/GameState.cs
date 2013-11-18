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

        public GameState()
        {
            this.GameStateNotation = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
            this.Moves = new List<GameMove>();
        }
        public void RegisterMove(GameMove move) {
        }
    }
}
