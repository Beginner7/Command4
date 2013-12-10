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
        Dictionary<Guid, User> users = new Dictionary<Guid, User>();

      
        public Guid UserUpdate(User user)
        {
            User currentUser;

            if (!users.TryGetValue(user.userId, out currentUser))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            currentUser.Name = user.Name;
            currentUser.Password = user.Password;
            return user.userId;
        }

        public Guid UserRegister(User user)
        {
            users.Add(user.userId, user);
            return user.userId;
        }

        public IEnumerable<User> GetUsers()
        {
            return users.Values;
        }
        public User GetUser(Guid userId)
        {
            User notation = null;
            users.TryGetValue(userId, out notation);
            return notation;
        }

        public User GetUser(string login, string password)
        {
            User user = new User();
          
            Guid userId = new Guid();

            foreach(User current_user in users.Values){
                if (current_user.Login==login && current_user.Password==password) userId=current_user.userId;
            }

            user = GetUser(userId);  

            return user;

        }
    }
}