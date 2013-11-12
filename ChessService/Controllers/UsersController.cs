using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ChessService.Models;
using Common;

namespace ChessService.Controllers
{
    public class UsersController : ApiController
    {
        readonly IUsersRepository respository;

        public UsersController(IUsersRepository repository)
        {
            this.respository = repository;
        }

        // GET api/users
        public IEnumerable<Users> Get()
        {
            return respository.GetUsers();
        }

        // GET api/users?login=ololoshka
        public Users Get(string login)
        {
            return respository.GetUser(login);
        }

        // Create
        public void Post(string login, string password, string name)
        {
            respository.UserRegister(new Users() { UserId = Guid.NewGuid(), Login = login, Name = name, Password = password });
        }

        //Update
        public void Post(string currentlogin, string currentpassword, string newname, string newpassword)
        {
            //respository.UserUpdate(new Users() { UserId = Guid.NewGuid(), Login = login, Name = name, Password = password });
        }
    }
}