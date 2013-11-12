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
            return null;// respository.GetUsers();
        }

        // GET api/users?login=ololoshka
        public Users Get(string login)
        {
            return null;// respository.GetUser(login);
        }

        // Create
        public void Post([FromBody] Users login, [FromBody] Users password, [FromBody] Users name)
        {
           //respository.RegisterUser(login,password,name);
        }

        //Update
        public void Post([FromBody] Users currentlogin, [FromBody] Users currentpassword, [FromBody] Users newname, [FromBody] Users newpassword)
        {
           // respository.UpdateUser(currentlogin, currentpassword, newname, newpassword);
        }
    }
}