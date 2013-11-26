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

      
        public Guid UserUpdate(Users user)
        {
            Users currentUser;

            if (!users.TryGetValue(user.userId, out currentUser))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            currentUser.Name = user.Name;
            currentUser.Password = user.Password;
            return user.userId;
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
            Users user = new Users();
          
            Guid userId = new Guid();

            foreach(Users current_user in users.Values){
                if (current_user.Login==login) userId=current_user.userId;
            }

            user = GetUser(userId);  

            return user;

        }
    }
}