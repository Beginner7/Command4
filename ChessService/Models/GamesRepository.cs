using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Common;

namespace ChessService.Models {
    public class GamesRepository : IGamesRepository {
        Dictionary<Guid, GameFiguresList> games = new Dictionary<Guid, GameFiguresList>();

        public Guid GameRequest(Guid gamer) {
            GameFiguresList gameState = new GameFiguresList();
            Guid gameId = Guid.NewGuid();
            games[gameId] = gameState;
            return gameId;
        }

        public Guid StartGame(GameState newGame) {
            games.Add(newGame.GameId, new GameFiguresList(newGame));
            return newGame.GameId;
        }

        public string RegisterMove(Guid gameId, GameMove move) {
            GameFiguresList gameState;
            if(!games.TryGetValue(gameId, out gameState)) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            gameState.ProcessMove(move);
            return gameState.GameState.GameStateNotation;
        }

        public IEnumerable<GameState> GetGames() {
            return games.Values.Select(g => g.GameState);
        }
        public GameState GetGame(Guid gameId) {
            GameFiguresList game = null;
            games.TryGetValue(gameId, out game);
            return game.GameState;
        }
    }
}