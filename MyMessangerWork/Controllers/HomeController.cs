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
            //string filePath = "Deafult";
            //if (userRequest.File != null && userRequest.File.Length > 0)
            //{
            //    // Определение пути для сохранения файла
            //     filePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", userRequest.File.FileName);

            //    // Создание директории, если она не существует
            //    if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            //    {
            //        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            //    }

            //    // Сохранение файла
            //    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await userRequest.File.CopyToAsync(fileStream);
            //    }
            //}
            var user = MyMessagerWork.Core.Model.User.Create(Guid.NewGuid(), userRequest.name, userRequest.email, userRequest.password/*, filePath*/);
            await _userService.AddAsyncUser(user.Value);
            return Ok(user.Value.Id);
        }
        [HttpPost("GetUser")]
        public async Task<IActionResult> GetUser([FromBody] string email)
        {
            var user =  await _userService.GetByEmailUser(email);
            return Ok(user);
        }
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return Ok();
        //}
    }
}
