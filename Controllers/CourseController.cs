using Microsoft.AspNetCore.Mvc;
using Test.Utils;
namespace Test.Controllers
{
    [ApiController]
    public class CourseController : ControllerBase
    {
        [HttpGet("/api/Authentication")]
        public string GetToken(string userName)
        {
            return Authetication.GenerateJsonWebToken();
        }
    }
}
