using Microsoft.AspNetCore.Mvc;
using API.Services;
using API.Controllers.Infrastructure;
using API.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        public ICourseService courseService;
        public CourseController(ICourseService _courseService)
        {
            courseService = _courseService;
        }


        [HttpGet("/api/Courses/{id}")]
        public Course GetById(string id)
        {
            Course course = new Course();
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                course = courseService.GetById(new Guid(id));
            }
            return course;
        }

        [HttpPost("/api/GetAllCourses")]
        public PagingDataSource<IEnumerable<Course>> GetAllExpand(GetAllCourses request)
        {
            var result = new PagingDataSource<IEnumerable<Course>> { Total = 0 };
            result.Data = courseService.GetAll(request.Expand).AsQueryable().ParseOData(request).ToList();
            result.Total = result.Data.Count();
            return result;
        }

        [HttpPost("/api/Courses")]
        public void Create(Course request)
        {
            Course course = new Course();
            try
            {

                if (request.Id != Guid.Empty)
                {
                    courseService.Update(request);
                }
                else
                {
                    courseService.Create(request);

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpDelete("/api/Courses/{id}")]
        public void Remove(string id)
        {
            Course course = new Course();
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                course = courseService.GetById(new Guid(id));
                courseService.Delete(course);
            }
        }
    }

    public class GetAllCourses : ODataRequest
    {
        public string[] Expand { set; get; }
    }
}



