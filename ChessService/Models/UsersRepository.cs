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
            Users user = new Users();
          
           /*
            * Guid userId = new Guid();

            foreach(Users current_user in users){
                if (current_user.Login.Equals(login)) userId=current_user.userId;
            }

            user = GetUser(userId);
         
                 
             //  this is don't work
            
             */

            return user;

          //  throw new NotImplementedException();
        }
    }
}