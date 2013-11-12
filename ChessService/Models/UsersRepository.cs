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

        public Guid UserRequest(Guid UserId)
        {
            //GameState gameState = new GameState();
            //Guid gameId = Guid.NewGuid();
            //users[gameId] = gameState;
            return Guid.Empty;
        }

        public Guid UserUpdate(Users NewUser)
        {
            Users currentUser;

            if (!users.TryGetValue(NewUser.UserId, out currentUser))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            currentUser.Name = NewUser.Name;
            currentUser.Password = NewUser.Password;
            return NewUser.UserId;
        }

        public Guid UserRegister(Users user)
        {
            users.Add(user.UserId, user);
            return user.UserId;
        }

        public IEnumerable<Users> GetUsers()
        {
            return users.Values;
        }
        public Users GetUser(Guid UserId)
        {
            Users notation = null;
            users.TryGetValue(UserId, out notation);
            return notation;
        }



        public Users GetUser(string login)
        {
            throw new NotImplementedException();
        }
    }
}