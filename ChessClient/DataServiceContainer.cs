using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChessClient.Controllers;
using ChessClient.DataService;
using ChessClient.Models;

namespace ChessClient {
    public class DataServiceContainer : IDependencyResolver {
        static readonly IDataService respository = new DataService.DataService(MvcApplication.SertviceUri);

        public object GetService(Type serviceType) {
            if(serviceType == typeof(GameController)) {
                return new GameController(respository);
            } else {
                if(serviceType == typeof(AccountController)) {
                    return new AccountController(respository);
                }
                return null;
            }
        }
        public IEnumerable<object> GetServices(Type serviceType) {
            return new List<object>();
        }
    }
}