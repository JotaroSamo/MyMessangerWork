using Microsoft.AspNetCore.Mvc;
using MyMessagerWork.Contracts;
using MyMessagerWork.Core.Abstract;

namespace MyMessagerWork.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return Ok();
        }
        public async Task<IActionResult> Register([FromBody]UserRequest userRequest)
        {
            var user = MyMessagerWork.Core.Model.User.Create(Guid.NewGuid(), userRequest.name, userRequest.email, userRequest.password);
           await _userService.AddAsyncUser(user.Value);
            return Ok();
        }
        public IActionResult Login()
        {
            return Ok();
        }
    }
}
