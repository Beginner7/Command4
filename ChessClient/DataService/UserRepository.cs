using System;
using System.Web;
using Common;
using ChessClient.Models;
using System.Collections.Generic;

namespace ChessClient.DataService
{
    public class UserRepository : Repository<User>, IUsersRepository
        
    {
        public UserRepository(string name, string baseUrl)
            : base(name, baseUrl)
        {
        }
        public RepositoryResult<User> AddUser(User user)
        {
            return Add(user); 
           
        }

        public RepositoryResult EditUser(User user)
        {
            return Update(user);
        }

        public RepositoryResult<System.Collections.Generic.IEnumerable<User>> GetUsers()
        {
            string url = GetUrl(null);
            return Get<IEnumerable<User>>(url);
        }

        public RepositoryResult<User> GetUser(Guid userId)
        {
            string parameters = string.Format("?userId={0}", userId);
            string url = GetUrl(parameters);
            return Get<User>(url);
           
        }
    }
}