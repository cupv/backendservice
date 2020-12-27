using Microsoft.AspNetCore.Mvc;
using API.Models;
using API.Utils;
namespace API.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet("/api/Authentication")]
        public string GetToken(User user)
        {
            return Authetication.GenerateJsonWebToken(user);
        }
        [HttpGet("/api/VerifyToken")]
        public string VerifyToken(string token)
        {
            return Authetication.VerifyJsonWebToken(token);
        }
    }
}
