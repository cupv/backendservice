using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Repositories;
using API.Models;
using API.Services.Infrastructure;

namespace API.Services
{
    public class CourseService : ServiceBase<Course>, ICourseService
    {
        public CourseService(ICourseRepository repository) : base(repository)
        {

        }
    }
}
