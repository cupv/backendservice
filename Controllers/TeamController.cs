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
    public class TeamController : ControllerBase
    {
        public ITeamService teamService;
        public TeamController(ITeamService _teamService)
        {
            teamService = _teamService;
        }

        [HttpGet("/api/Team/{id}")]
        public Team GetById(string id)
        {
            Team team = new Team();
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                team = teamService.GetById(new Guid(id));
            }
            return team;
        }

        [HttpPost("/api/GetAllTeam")]
        public PagingDataSource<IEnumerable<Team>> GetAllExpand(GetAllTeam request)
        {
            var result = new PagingDataSource<IEnumerable<Team>> { Total = 0 };
            result.Data = teamService.GetAll(request.Expand).AsQueryable().ParseOData(request).ToList();
            result.Total = result.Data.Count();
            return result;
        }

        [HttpPost("/api/Team")]
        public void Create(Team request)
        {
            Team team = new Team();
            try
            {

                if (request.Id != Guid.Empty)
                {
                    teamService.Update(request);
                }
                else
                {
                    teamService.Create(request);

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpDelete("/api/Team/{id}")]
        public void Remove(string id)
        {
            Team Team = new Team();
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                Team = teamService.GetById(new Guid(id));
                teamService.Delete(Team);
            }
        }
    }

    public class GetAllTeam : ODataRequest
    {
        public string[] Expand { set; get; }
    }
}



