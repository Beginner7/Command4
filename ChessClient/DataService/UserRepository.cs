using System;
using System.Web;
using Common;
using ChessClient.Models;
using System.Collections.Generic;

namespace ChessClient.DataService
{
    public class UserRepository : Repository<Users>, IUserRepository
        
    {
        public UserRepository(string name, string baseUrl)
            : base(name, baseUrl)
        {
        }
        public RepositoryResult<Users> AddUser(Users user)
        {
            return Add(user); 
           
        }

        public RepositoryResult EditUser(Users user)
        {
            return Update(user);
        }

        public RepositoryResult<System.Collections.Generic.IEnumerable<Users>> GetUsers()
        {
            string url = GetUrl(null);
            return Get<IEnumerable<Users>>(url);
        }

        public RepositoryResult<Users> GetUser(Guid userId)
        {
            string parameters = string.Format("?userId={0}", userId);
            string url = GetUrl(parameters);
            return Get<Users>(url);
           
        }
    }
}