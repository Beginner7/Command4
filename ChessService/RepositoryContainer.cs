using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using ChessService.Controllers;
using ChessService.Models;

namespace ChessService.Models {
    public class RepositoryContainer : IDependencyResolver {
        static readonly IGamesRepository games = new GamesRepository();
        static readonly IUsersRepository users = new UsersRepository();

        static RepositoryContainer() {
            Common.GameState fakeGame = new Common.GameState() {
                BlackGamer = Guid.Parse("{6FD1D512-A178-4ED8-AC24-B98B2C2EE5ED}"),
                WhiteGamer = Guid.Parse("{9D3C6BEB-08D5-458D-82DA-1046EC616BC7}"),
                GameId = Guid.Parse("{46BF4054-2274-4F8D-950C-08E25A08899C}")
            };
            games.StartGame(fakeGame);
            Common.User fakeUser = new Common.User() {
                Login = "Login",
                Name = "Name",
                Password = "Password",
                userId = Guid.NewGuid()
            };
            users.UserRegister(fakeUser);
        }

        public IDependencyScope BeginScope() {
            return this;
        }
        public object GetService(Type serviceType) {
            if(serviceType == typeof(GamesController)) {
                return new GamesController(games);
            } else if(serviceType == typeof(UsersController)) {
                return new UsersController(users);
            } else {
                return null;
            }
        }
        public IEnumerable<object> GetServices(Type serviceType) {
            return new List<object>();
        }
        public void Dispose() {
        }
    }
}