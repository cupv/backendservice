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
    public class LessionController : ControllerBase
    {
        public ILessionService lessionService;
        public LessionController(ILessionService _lessionService)
        {
            lessionService = _lessionService;
        }


        [HttpGet("/api/Lession/{id}")]
        public Lession GetById(string id)
        {
            Lession lession = new Lession();
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                lession = lessionService.GetById(new Guid(id));
            }
            return lession;
        }

        [HttpPost("/api/GetAllLession")]
        public PagingDataSource<IEnumerable<Lession>> GetAllExpand(GetAllLession request)
        {
            var result = new PagingDataSource<IEnumerable<Lession>> { Total = 0 };
            result.Data = lessionService.GetAll(request.Expand).AsQueryable().ParseOData(request).ToList();
            result.Total = result.Data.Count();
            return result;
        }

        [HttpPost("/api/Lession")]
        public void Create(Lession request)
        {
            Lession course = new Lession();
            try
            {

                if (request.Id != Guid.Empty)
                {
                    lessionService.Update(request);
                }
                else
                {
                    lessionService.Create(request);

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpDelete("/api/Lession/{id}")]
        public void Remove(string id)
        {
            Lession lession = new Lession();
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                lession = lessionService.GetById(new Guid(id));
                lessionService.Delete(lession);
            }
        }
    }

    public class GetAllLession : ODataRequest
    {
        public string[] Expand { set; get; }
    }
}



