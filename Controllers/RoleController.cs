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
    public class RoleController : ControllerBase
    {
        public IRoleService roleService;
        public RoleController(IRoleService _roleService)
        {
            roleService = _roleService;
        }


        [HttpGet("/api/Roles/{id}")]
        public Role GetById(string id)
        {
            Role role = new Role();
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                role = roleService.GetById(new Guid(id));
            }
            return role;
        }

        [HttpPost("/api/GetAllRoles")]
        public PagingDataSource<IEnumerable<Role>> GetAllExpand(GetAllRoles request)
        {
            var result = new PagingDataSource<IEnumerable<Role>> { Total = 0 };
            result.Data = roleService.GetAll(request.Expand).AsQueryable().ParseOData(request).ToList();
            result.Total = result.Data.Count();
            return result;
        }

        [HttpPost("/api/Roles")]
        public void Create(Role request)
        {
            Role role = new Role();
            try
            {

                if (request.Id != Guid.Empty)
                {
                    roleService.Update(request);
                }
                else
                {
                    roleService.Create(request);

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpDelete("/api/Roles/{id}")]
        public void Remove(string id)
        {
            Role role = new Role();
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                role = roleService.GetById(new Guid(id));
                roleService.Delete(role);
            }
        }
    }

    public class GetAllRoles : ODataRequest
    {
        public string[] Expand { set; get; }
    }
}



