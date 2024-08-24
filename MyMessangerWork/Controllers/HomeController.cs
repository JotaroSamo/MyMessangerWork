using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMessagerWork.Contracts;
using MyMessagerWork.Core.Abstract;
using MyMessagerWork.Core.Model;

namespace MyMessagerWork.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

    

        public HomeController(IUserService userService)
        {
            _userService = userService;
  
        }
       
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserRequest userRequest)
        {
            var user = await _userService.Register(userRequest.name, userRequest.email, userRequest.password);
            return Ok(user.Value.Id);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email,string password)
        {
          var token = await _userService.Login(email, password);
           
          Response.Cookies.Append("tasty-cookies", token.Value);
            
          return Ok(token.Value);
        }
        [HttpPost("GetUser")]
        public async Task<IActionResult> GetUser([FromBody] string email)
        {
            var user =  await _userService.GetByEmailUser(email);
            if (user is null)
            {
                return BadRequest();
            } 
            return Ok(user);
        }
       
    }
}
