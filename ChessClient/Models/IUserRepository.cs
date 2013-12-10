using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChessClient.DataService;
using Common;

namespace ChessClient.Models
{
    public interface IUsersRepository
    {
        RepositoryResult<User> AddUser(User user);
        RepositoryResult EditUser(User user);
        RepositoryResult<IEnumerable<User>> GetUsers();
        RepositoryResult<User> GetUser(Guid userId);
    
    }
}