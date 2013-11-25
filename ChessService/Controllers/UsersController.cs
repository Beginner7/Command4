﻿using System;
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
        readonly IUsersRepository repository;

        public UsersController(IUsersRepository repository)
        {
            this.repository = repository;
        }

        // GET api/users
        public IEnumerable<Users> Get()
        {
            return repository.GetUsers();
        }

        // GET api/users?login=ololoshka
        public Users Get(string login)
        {
            return repository.GetUser(login);
        }

        // GET api/users?userId=C601A3DA-69D9-4301-BA78-8406D1C8BA2B
        public Users Get(Guid userId) {
            return repository.GetUser(userId);
        }

        // Register
        public void Post(string login, string password, string name)
        {
            repository.UserRegister(new Users() { userId = Guid.NewGuid(), Login = login, Name = name, Password = password });
        }

        // Update
        public void Post(string currentLogin, string currentPassword, string newName, string newPassword)
        {
            //repository.UserUpdate(new Users() { UserId = Guid.NewGuid(), Login = login, Name = name, Password = password });
        }
    }
}