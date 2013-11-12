using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChessClient.DataService;
using Common;

namespace ChessClient.Models
{
    public interface IUserRepository
    {
        RepositoryResult<Users> AddUser(Users user);
        RepositoryResult EditUser(Users user);
        RepositoryResult<IEnumerable<Users>> GetUsers();
        RepositoryResult<Users> GetUser(Guid userId);
    
    }
}