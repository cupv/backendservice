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
    public class QuestionController : ControllerBase
    {
        public IQuestionService questionService;
        public QuestionController(IQuestionService _questionService)
        {
            questionService = _questionService;
        }


        [HttpGet("/api/Question/{id}")]
        public Question GetById(string id)
        {
            Question question = new Question();
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                question = questionService.GetById(new Guid(id));
            }
            return question;
        }

        [HttpPost("/api/GetAllQuestion")]
        public PagingDataSource<IEnumerable<Question>> GetAllExpand(GetAllQuestion request)
        {
            var result = new PagingDataSource<IEnumerable<Question>> { Total = 0 };
            result.Data = questionService.GetAll(request.Expand).AsQueryable().ParseOData(request).ToList();
            result.Total = result.Data.Count();
            return result;
        }

        [HttpPost("/api/Question")]
        public void Create(Question request)
        {
            Question question = new Question();
            try
            {

                if (request.Id != Guid.Empty)
                {
                    questionService.Update(request);
                }
                else
                {
                    questionService.Create(request);

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpDelete("/api/Question/{id}")]
        public void Remove(string id)
        {
            Question question = new Question();
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                question = questionService.GetById(new Guid(id));
                questionService.Delete(question);
            }
        }
    }

    public class GetAllQuestion : ODataRequest
    {
        public string[] Expand { set; get; }
    }
}



