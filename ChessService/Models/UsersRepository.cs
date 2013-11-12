using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Common;

namespace ChessService.Models
{
    public class UsersRepository : IUsersRepository
    {
        Dictionary<Guid, Users> users = new Dictionary<Guid, Users>();

        public Guid GameRequest(Guid gamer)
        {
            //GameState gameState = new GameState();
            //Guid gameId = Guid.NewGuid();
            //users[gameId] = gameState;
            return Guid.Empty;
        }

        public Guid StartGame(GameState newGame)
        {
            //games.Add(newGame.GameId, newGame);
            return newGame.GameId;
        }

        public string RegisterMove(Guid gameId, GameMove move)
        {
            GameState gameState;
            //if (!games.TryGetValue(gameId, out gameState))
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            //gameState.RegisterMove(move);
            return null;// gameState.GameStateNotation;
        }

        public IEnumerable<GameState> GetUsers()
        {
            return null;
        }
        public GameState GetGame(Guid gameId)
        {
            GameState notation = null;
            //games.TryGetValue(gameId, out notation);
            return notation;
        }


        public Guid StartGame(Users newGame)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> GetGames()
        {
            throw new NotImplementedException();
        }

        Users IUsersRepository.GetGame(Guid gameId)
        {
            throw new NotImplementedException();
        }
    }
}