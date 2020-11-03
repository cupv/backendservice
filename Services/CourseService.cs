using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Repositories;
using Test.Models;
using Test.Services.Infrastructure;

namespace Test.Services
{
    public class CourseService : ServiceBase<Course>, ICourseService
    {
        public CourseService(ICourseRepository repository) : base(repository)
        {

        }
    }
}
