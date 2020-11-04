using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Utils;
namespace Test.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet("/api/Authentication")]
        public string GetToken(User user)
        {
            return Authetication.GenerateJsonWebToken(user);
        }
    }
}
