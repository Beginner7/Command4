using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessClient.DataService;
using ChessClient.Models;
using Common;

namespace ChessClient.Tests {
    public class DataServiceForTest : IDataService {
        public IGamesRepository Games { get; private set; }

        public DataServiceForTest() {
            Games = new GameRepositoryForTest();
        }


        public IGamesRepository User
        {get ; private set; }
    }

    public class GameRepositoryForTest : IGamesRepository {
        Dictionary<Guid, GameState> games = new Dictionary<Guid, GameState>();

        public DataService.RepositoryResult<GameState> StartGame(Guid gameRequest, Guid whiteGamer, Guid blackGamer) {
            GameState game = new GameState() { GameId = gameRequest, BlackGamer = blackGamer, WhiteGamer = whiteGamer };
            games.Add(gameRequest, game);
            return new RepositoryResult<GameState>() { Value = game, IsSuccessStatusCode = true };
        }
        public DataService.RepositoryResult RegisterMove(Guid gameId, GameMove move) {
            GameState game;
            if(!games.TryGetValue(gameId, out game)) {
                return new RepositoryResult() { IsSuccessStatusCode = false, Exception = new ArgumentException() };
            }
            List<GameMove> moves = new List<GameMove>(game.Moves);
            moves.Add(move);
            game.Moves = moves;
            return new RepositoryResult() { IsSuccessStatusCode = true };
        }
        public DataService.RepositoryResult<IEnumerable<GameState>> GetGames() {
            return new RepositoryResult<IEnumerable<GameState>>() { Value = games.Values, IsSuccessStatusCode = true };
        }
        public DataService.RepositoryResult<GameState> GetGame(Guid gameId) {
            GameState game;
            if(!games.TryGetValue(gameId, out game)) {
                new RepositoryResult<GameState>() { IsSuccessStatusCode = false, Exception = new ArgumentException() };
            }
            return new RepositoryResult<GameState>() { Value = game, IsSuccessStatusCode = true };
        }
    }
}
