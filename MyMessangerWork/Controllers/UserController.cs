using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyMessagerWork.Controllers
{
    [Authorize]
    [Controller]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
