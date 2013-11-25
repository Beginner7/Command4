using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Common;

namespace ChessService.Models
{
    public class UsersRepository : IUsersRepository
    {
        Dictionary<Guid, Users> users = new Dictionary<Guid, Users>();

      
        public Guid UserUpdate(Users newUser)
        {
            Users currentUser;

            if (!users.TryGetValue(newUser.userId, out currentUser))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            currentUser.Name = newUser.Name;
            currentUser.Password = newUser.Password;
            return newUser.userId;
        }

        public Guid UserRegister(Users user)
        {
            users.Add(user.userId, user);
            return user.userId;
        }

        public IEnumerable<Users> GetUsers()
        {
            return users.Values;
        }
        public Users GetUser(Guid userId)
        {
            Users notation = null;
            users.TryGetValue(userId, out notation);
            return notation;
        }

        public Users GetUser(string login)
        {
            Users user = null;
            return user;
          //  throw new NotImplementedException();
        }
    }
}