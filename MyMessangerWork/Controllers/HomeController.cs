using Microsoft.AspNetCore.Mvc;
using MyMessagerWork.Contracts;
using MyMessagerWork.Core.Abstract;

namespace MyMessagerWork.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return Ok();
        //}
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserRequest userRequest)
        {
            var user = MyMessagerWork.Core.Model.User.Create(Guid.NewGuid(), userRequest.name, userRequest.email, userRequest.password);
            await _userService.AddAsyncUser(user.Value);
            return Ok(user.Value.Id);
        }
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return Ok();
        //}
    }
}
