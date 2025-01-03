using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Resume.MVC.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
    }
}
