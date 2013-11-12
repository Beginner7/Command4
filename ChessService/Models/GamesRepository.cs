using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Common;

namespace ChessService.Models {
    public class GamesRepository : IGamesRepository {
        Dictionary<Guid, GameState> games = new Dictionary<Guid, GameState>();

        public Guid GameRequest(Guid gamer) {
            GameState gameState = new GameState();
            Guid gameId = Guid.NewGuid();
            games[gameId] = gameState;
            return gameId;
        }

        public Guid StartGame(GameState newGame) {
            games.Add(newGame.GameId, newGame);
            return newGame.GameId;
        }

        public string RegisterMove(Guid gameId, GameMove move) {
            GameState gameState;
            if(!games.TryGetValue(gameId, out gameState)) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            gameState.RegisterMove(move);
            return gameState.GameStateNotation;
        }

        public IEnumerable<GameState> GetGames() {
            return games.Values;
        }
        public GameState GetGame(Guid gameId) {
            GameState notation = null;
            games.TryGetValue(gameId, out notation);
            return notation;
        }
    }
}