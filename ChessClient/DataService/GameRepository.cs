using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChessClient.Models;
using Common;

namespace ChessClient.DataService {
    public class GameRepository : Repository<GameState>, IGamesRepository {
        public GameRepository(string name, string baseUrl)
            : base(name, baseUrl) {
        }

        public RepositoryResult<GameState> StartGame(Guid gameRequest, Guid whiteGamer, Guid blackGamer) {
            return Add(new GameState() { BlackGamer = blackGamer, WhiteGamer = whiteGamer, GameId = Guid.NewGuid() });
        }
        public RepositoryResult RegisterMove(Guid gameId, GameMove move) {
            RepositoryResult<GameState> gameState = GetGame(gameId);
            if(!gameState.IsSuccessStatusCode) {
                return new RepositoryResult<string>() { Exception = gameState.Exception, IsSuccessStatusCode = false, StatusCode = gameState.StatusCode, Value = null };
            }
            List<GameMove> moves = new List<GameMove>(gameState.Value.Moves);
            moves.Add(move);
            gameState.Value.Moves = moves;
            gameState.Value.RegisterMove(move);
            return Update(gameState.Value);
        }
        public RepositoryResult<IEnumerable<GameState>> GetGames() {
            string url = GetUrl(null);
            return Get<IEnumerable<GameState>>(url);
        }
        public RepositoryResult<GameState> GetGame(Guid gameId) {
            string parameters = string.Format("?gameId={0}", gameId);
            string url = GetUrl(parameters);
            return Get<GameState>(url);
        }
    }
}