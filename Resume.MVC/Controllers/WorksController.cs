using Microsoft.AspNetCore.Mvc;

namespace Resume.MVC.Controllers
{
    public class WorksController : SiteBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
