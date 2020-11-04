using Microsoft.AspNetCore.Mvc;
using Test.Services;
using Test.Controllers.Infrastructure;
using Test.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Test.Utils;
using Test.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Test.Data;

namespace Test.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService userService;
        public TestContext context;
        public UserController(IUserService _userService)
        {
            userService = _userService;
            context = new FactoryContext().Init();
        }

        [HttpGet("/api/User/{id}")]
        public User GetById(string id)
        {
            User user = new User();
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                user = userService.GetById(new Guid(id));
            }
            return user;
        }

        [HttpPost("/api/GetAllUsers")]
        public PagingDataSource<IEnumerable<User>> GetAllExpand(GetAllUsers request)
        {
            var result = new PagingDataSource<IEnumerable<User>> { Total = 0 };
            result.Data = userService.GetAll(request.Expand).AsQueryable().ParseOData(request).ToList();
            result.Total = result.Data.Count();
            return result;
        }

        [HttpPost("/api/Register")]
        public void Register(User user)
        {
            User _user = new User();
            try
            {
                var hashsalt = Utils.Utils.EncryptPassword(user.Password);
                user.Password = hashsalt.Hash;
                user.Salt = hashsalt.Salt;
                userService.Create(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost("/api/Login")]
        public string SignIn(User user)
        {
            User _user = new User();
            try
            {
                _user = context.Users.FirstOrDefault(u => u.UserName == user.UserName);
                var results = Utils.Utils.VerifyPassword(user.Password, _user.Salt, _user.Password);
                if (results)
                {
                    return Authetication.GenerateJsonWebToken(_user);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpDelete("/api/Users/{id}")]
        public void Remove(string id)
        {
            User lession = new User();
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                lession = userService.GetById(new Guid(id));
                userService.Delete(lession);
            }
        }
    }

    public class GetAllUsers : ODataRequest
    {
        public string[] Expand { set; get; }
    }
}



