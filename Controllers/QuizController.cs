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
    public class QuizController : ControllerBase
    {
        public IQuizService quizService;
        public QuizController(IQuizService _quizService)
        {
            quizService = _quizService;
        }


        [HttpGet("/api/Quiz/{id}")]
        public Quiz GetById(string id)
        {
            Quiz quiz = new Quiz();
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                quiz = quizService.GetById(new Guid(id));
            }
            return quiz;
        }

        [HttpPost("/api/GetAllQuiz")]
        public PagingDataSource<IEnumerable<Quiz>> GetAllExpand(GetAllQuiz request)
        {
            var result = new PagingDataSource<IEnumerable<Quiz>> { Total = 0 };
            result.Data = quizService.GetAll(request.Expand).AsQueryable().ParseOData(request).ToList();
            result.Total = result.Data.Count();
            return result;
        }

        [HttpPost("/api/Quiz")]
        public Quiz Create(Quiz request)
        {
            Quiz quiz = new Quiz();
            try
            {

                if (request.Id != Guid.Empty)
                {
                    quizService.Update(request);
                }
                else
                {
                    quizService.Create(request);

                }
                return request;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpDelete("/api/Quiz/{id}")]
        public void Remove(string id)
        {
            Quiz quiz = new Quiz();
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                quiz = quizService.GetById(new Guid(id));
                quizService.Delete(quiz);
            }
        }
    }

    public class GetAllQuiz : ODataRequest
    {
        public string[] Expand { set; get; }
    }
}



