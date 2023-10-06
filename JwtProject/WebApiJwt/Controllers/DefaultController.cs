using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiJwt.Models;

namespace WebApiJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        // This actionresult goes to the "TokenCreate" method which in "CreateToken" class
        [HttpGet("[action]")]
        public IActionResult BuildTokenTest()
        {
            return Ok(new CreateToken().TokenCreate());
        }

        // This actionresult goes to the "TokenCreateAdmin" method which in "CreateToken" class
        [HttpGet("[action]")]
        public IActionResult BuildTokenAdmin()
        {
            return Ok(new CreateToken().TokenCreateAdmin());
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult Test2()
        {
            return Ok("Welcome to your first Token :)");
        }

        [Authorize(Roles = "Admin,Visitor")]
        [HttpGet("[action]")]
        public IActionResult Test3()
        {
            return Ok("Token worked well for admin and visitor!");
        }
    }
}
