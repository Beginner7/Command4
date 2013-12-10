using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChessClient.DataService;
using ChessClient.Models;
using Common;

namespace ChessClient.Controllers {
    public class GameController : Controller {
        // GameRepository gamerepository = new GameRepository("name","baseurl");
        readonly IDataService repository;

        public GameController(IDataService repository) {
            this.repository = repository;
        }

        public string GetCellSymbolAndNumber(int x, int y) {
            char Symbol = ' ';
            switch(y) {
                case 0: Symbol = 'a'; break;
                case 1: Symbol = 'b'; break;
                case 2: Symbol = 'c'; break;
                case 3: Symbol = 'd'; break;
                case 4: Symbol = 'e'; break;
                case 5: Symbol = 'f'; break;
                case 6: Symbol = 'g'; break;
                case 7: Symbol = 'h'; break;
            }
            int Number = 8 - x;
            return Symbol.ToString() + Number.ToString();
        }

        public string ConvertToGameMove(int xfrom, int yfrom, int xto, int yto) {
            String From = GetCellSymbolAndNumber(xfrom, yfrom);
            String To = GetCellSymbolAndNumber(xto, yto);
            return From + " " + To;
        }

        //
        // GET: /Game/
        [HttpGet]
        public ActionResult Index() {

            //RepositoryResult<IEnumerable<GameState>> result = repository.Games.GetGames();
            //if(result.IsSuccessStatusCode) {
            //    return View("GameList", result.Value);
            //} else {
            //    throw new InvalidOperationException(result.Exception.GetBaseException().Message);
            //}
            GameState gamestate = new GameState();
            return View("GameList", gamestate);
        }

        [HttpGet]
        public ActionResult ShowGame(Guid gameId) {
            RepositoryResult<GameState> result = repository.Games.GetGame(gameId);
            GameModel gamemodel = new GameModel(result.Value);
            if(result.IsSuccessStatusCode) {
                return View("Game", gamemodel);
            } else {
                throw new InvalidOperationException(result.Exception.GetBaseException().Message);
            }
            //   repository.Games.RegisterMove(
        }

        [HttpGet]
        public ActionResult Current(Guid gameId, int x, int y) {
            RepositoryResult<GameState> result = repository.Games.GetGame(gameId);
            GameModel gamemodel = new GameModel(result.Value);
            switch(gamemodel.cells[x, y].Type) {
                case FigureType.Rook: {
                        gamemodel.CurrentMoves = gamemodel.rookMove(x, y);
                        break;
                    }
                case FigureType.Knight: {
                        gamemodel.CurrentMoves = gamemodel.knightMove(x, y);
                        break;
                    }
                case FigureType.Bishop: {
                        gamemodel.CurrentMoves = gamemodel.bishopMove(x, y);
                        break;
                    }
                case FigureType.King: {
                        gamemodel.CurrentMoves = gamemodel.kingMove(x, y);
                        break;
                    }
                case FigureType.Queen: {
                        gamemodel.CurrentMoves = gamemodel.queenMove(x, y);
                        break;
                    }
                case FigureType.Pawn: {
                        if(gamemodel.cells[x, y].Color == FigureColor.White) {
                            gamemodel.CurrentMoves = gamemodel.pawnWhiteMove(x, y);
                            break;
                        } else {
                            gamemodel.CurrentMoves = gamemodel.pawnBlackMove(x, y);
                            break;
                        }
                    }
            };
            gamemodel.CssClass();
            gamemodel.CurrentFigure.x = x;
            gamemodel.CurrentFigure.y = y;
            return View("Game", gamemodel);

        }

        [HttpGet]
        public ActionResult CurrentMove(Guid gameId, int xfrom, int yfrom, int xto, int yto) {
            GameMove gameMove = new GameMove();
            gameMove.MoveNotation = ConvertToGameMove(xfrom, yfrom, xto, yto);
            RepositoryResult resultMoveRegister = repository.Games.RegisterMove(gameId, gameMove);
            if(!resultMoveRegister.IsSuccessStatusCode)
                throw new InvalidOperationException(resultMoveRegister.Exception.GetBaseException().Message);
            RepositoryResult<GameState> resultGameLoad = repository.Games.GetGame(gameId);
            GameModel gamemodel = new GameModel(resultGameLoad.Value);
            if(resultMoveRegister.IsSuccessStatusCode) {
                return View("Game", gamemodel);
            } else {
                throw new InvalidOperationException(resultMoveRegister.Exception.GetBaseException().Message);
            }
        }



        //[HttpPost]
        //public ActionResult ShowGame(Guid gameId, int xfrom , int yfrom, int xto, int yto) {
        //    GameMove gamemove = new GameMove();
        //    //string move = ConvertToGameMove(int xfrom , int yfrom, int xto, int yto);
        //    gamemove.MoveNotation = ""; //
        //    RepositoryResult resultMove = repository.Games.RegisterMove(gameId, gamemove);
        //    if(resultMove.IsSuccessStatusCode) {
        //        RepositoryResult<GameState> resultGame = repository.Games.GetGame(gameId);
        //        if(resultGame.IsSuccessStatusCode) {
        //            GameModel gamemodel = new GameModel(resultGame.Value);
        //            return View("Game", gamemodel);
        //        }
        //    }
        //    return null;
        //}

        [HttpPost]
        public ActionResult ShowGame(Guid gameId, [System.Web.Http.FromBody] string move) {
            GameMove gameMove = new GameMove();
            // gameMove.MoveNotation = ConvertToGameMove(int xfrom , int yfrom, int xto, int yto);
            RepositoryResult resultMoveRegister = repository.Games.RegisterMove(gameId, gameMove);
            if(!resultMoveRegister.IsSuccessStatusCode)
                throw new InvalidOperationException(resultMoveRegister.Exception.GetBaseException().Message);
            RepositoryResult<GameState> resultGameLoad = repository.Games.GetGame(gameId);
            GameModel gamemodel = new GameModel(resultGameLoad.Value);
            if(resultMoveRegister.IsSuccessStatusCode) {
                return View("Game", gamemodel);
            } else { 
                throw new InvalidOperationException(resultMoveRegister.Exception.GetBaseException().Message);
            }
            
        }




    }
}
