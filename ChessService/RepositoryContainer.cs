using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using ChessService.Controllers;
using ChessService.Models;

namespace ChessService.Models {
    public class RepositoryContainer : IDependencyResolver {
        static readonly IGamesRepository respository = new GamesRepository();

        public IDependencyScope BeginScope() {
            return this;
        }
        public object GetService(Type serviceType) {
            if(serviceType == typeof(GamesController)) {
                return new GamesController(respository);
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