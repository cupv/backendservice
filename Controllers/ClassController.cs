using Microsoft.AspNetCore.Mvc;
using Test.Services;
using Test.Controllers.Infrastructure;
using Test.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Test.Controllers
{
    [ApiController]
    [Authorize]
    public class ClassController : ControllerBase
    {
        public IClassService classService;
        public ClassController(IClassService _classService)
        {
            classService = _classService;
        }


        [HttpGet("/api/Class/{id}")]
        public Class GetById(string id)
        {
            Class _class = new Class();
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _class = classService.GetById(new Guid(id));
            }
            return _class;
        }

        [HttpPost("/api/GetAllClass")]
        public PagingDataSource<IEnumerable<Class>> GetAllExpand(GetAllClass request)
        {
            var result = new PagingDataSource<IEnumerable<Class>> { Total = 0 };
            result.Data = classService.GetAll(request.Expand).AsQueryable().ParseOData(request).ToList();
            result.Total = result.Data.Count();
            return result;
        }

        [HttpPost("/api/Class")]
        public void Create(Class request)
        {
            Class _class = new Class();
            try
            {

                if (request.Id != Guid.Empty)
                {
                    classService.Update(request);
                }
                else
                {
                    classService.Create(request);

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpDelete("/api/Class/{id}")]
        public void Remove(string id)
        {
            Class _class = new Class();
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _class = classService.GetById(new Guid(id));
                classService.Delete(_class);
            }
        }
    }

    public class GetAllClass : ODataRequest
    {
        public string[] Expand { set; get; }
    }
}



