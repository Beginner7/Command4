using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ChessService.Models;
using Common;

namespace ChessService.Controllers {
    public class GamesController : ApiController {
        readonly IGamesRepository respository;

        public GamesController(IGamesRepository repository) {
            this.respository = repository;
        }

        // GET api/games
        public IEnumerable<GameState> Get() {
            return respository.GetGames();
        }

        // GET api/games?gameId=C601A3DA-69D9-4301-BA78-8406D1C8BA2B
        public GameState Get(Guid gameId) {
            return respository.GetGame(gameId);
        }

        // POST api/games
        public void Post([FromBody] GameMove move) {
            respository.RegisterMove(move);
        }
    }
}