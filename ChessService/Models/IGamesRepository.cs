using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace ChessService.Models {
    public interface IGamesRepository {
        Guid GameRequest(Guid gamer);
        Guid StartGame(GameState newGame);
        string RegisterMove(Guid gameId, GameMove move);
        IEnumerable<GameState> GetGames();
        GameState GetGame(Guid gameId);
    }
}
