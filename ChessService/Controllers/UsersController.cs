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
        public IEnumerable<User> Get()
        {
            return repository.GetUsers();
        }

        // GET api/users?login=ololoshka
        public User Get(string login, string password)
        {
            return repository.GetUser(login,password);
        }

        // GET api/users?userId=C601A3DA-69D9-4301-BA78-8406D1C8BA2B
        public User Get(Guid userId) {
            return repository.GetUser(userId);
        }

        // Register
        public void Post(User user)
        {
            repository.UserRegister(user);
        }

        // Update
        public void Put(User user)
        {
            repository.UserUpdate(user);
        }
    }
}