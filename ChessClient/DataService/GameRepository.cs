using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace ChessClient.DataService {
    public class GameRepository : Repository<GameState> {
        public GameRepository(string name, string baseUrl)
            : base(name, baseUrl) {
        }
    }
}