using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChessClient.Models;

namespace ChessClient.DataService {
    public interface IDataService {
        IGamesRepository Games { get; }
        IGamesRepository User { get; }
    }

    public class DataService : IDataService {
        public IGamesRepository Games { get; private set; }
        public IGamesRepository User { get; private set; }

        public DataService(string serviceUrl) {
            Games = new GameRepository("games", serviceUrl);
            User = new GameRepository("user", serviceUrl);
        }

    }
}