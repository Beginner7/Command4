using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessClient.DataService;
using Common;

namespace ChessClient.Models {
    public interface IGamesRepository {
        RepositoryResult<GameState> StartGame(Guid gameRequest, Guid whiteGamer, Guid blackGamer);
        RepositoryResult RegisterMove(Guid gameId, GameMove move);
        RepositoryResult<IEnumerable<GameState>> GetGames();
        RepositoryResult<GameState> GetGame(Guid gameId);
    }
}
