using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMessagerWork.Contracts;
using MyMessagerWork.Core.Abstract;

namespace MyMessagerWork.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        private readonly IPasswordHasher _passwordHasher;

        public HomeController(IUserService userService, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
        }
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return Ok();
        //}
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserRequest userRequest)
        {

            var hashedpassword = _passwordHasher.Generate(userRequest.password);
            var user = MyMessagerWork.Core.Model.User.Create(Guid.NewGuid(), userRequest.name, userRequest.email, hashedpassword/*, filePath*/);
            await _userService.AddAsyncUser(user.Value);
            return Ok(user.Value.Id);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email,string password)
        {
            var user = await _userService.GetByEmailUser(email);
            if (user == null)
            {
                return BadRequest();
            }
            if (_passwordHasher.Verify(password, user.HashPassword))
            {
                return Ok(user);
            }
            return BadRequest();

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
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return Ok();
        //}
    }
}
