using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace ChessService.Models
{
    public interface IUsersRepository
    {
        Guid GameRequest(Guid gamer);
        Guid StartGame(Users newGame);
        string RegisterMove(Guid gameId, GameMove move);
        IEnumerable<Users> GetGames();
        Users GetGame(Guid gameId);
    }
}
