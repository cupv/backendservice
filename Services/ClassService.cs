using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Repositories;
using Test.Models;
using Test.Services.Infrastructure;

namespace Test.Services
{
    public class ClassService : ServiceBase<Class>, IClassService
    {
        public ClassService(IClassRepository repository) : base(repository)
        {

        }
    }
}
