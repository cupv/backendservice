using Microsoft.AspNetCore.Mvc;
using API.Services;
using API.Controllers.Infrastructure;
using API.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace API.Controllers
{
    [ApiController]
    public class LessonController : ControllerBase
    {
        public ILessonService lessonService;
        public LessonController(ILessonService _lessonService)
        {
            lessonService = _lessonService;
        }


        [HttpGet("/api/Lesson/{id}")]
        public Lesson GetById(string id)
        {
            Lesson lesson = new Lesson();
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                lesson = lessonService.GetById(new Guid(id));
            }
            return lesson;
        }

        [HttpPost("/api/GetAllLesson")]
        public PagingDataSource<IEnumerable<Lesson>> GetAllExpand(GetAllLesson request)
        {
            var result = new PagingDataSource<IEnumerable<Lesson>> { Total = 0 };
            result.Data = lessonService.GetAll(request.Expand).AsQueryable().ParseOData(request).ToList();
            result.Total = result.Data.Count();
            return result;
        }

        [HttpPost("/api/Lesson")]
        public void Create(Lesson request)
        {
            Lesson course = new Lesson();
            try
            {

                if (request.Id != Guid.Empty)
                {
                    lessonService.Update(request);
                }
                else
                {
                    lessonService.Create(request);

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpDelete("/api/Lesson/{id}")]
        public void Remove(string id)
        {
            Lesson lesson = new Lesson();
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                lesson = lessonService.GetById(new Guid(id));
                lessonService.Delete(lesson);
            }
        }
    }

    public class GetAllLesson : ODataRequest
    {
        public string[] Expand { set; get; }
    }
}



