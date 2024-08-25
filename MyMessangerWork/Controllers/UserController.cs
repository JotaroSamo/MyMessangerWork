using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMessagerWork.Core.Abstract;

namespace MyMessagerWork.Controllers
{
    [Authorize]
    [Controller]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
                _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
          var users = await _userService.GetAllListUserAsync();
            return Ok(users);
        }
    }
}
