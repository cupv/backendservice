using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Repositories;
using Test.Models;
using Test.Services.Infrastructure;

namespace Test.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {

        }
    }
}
