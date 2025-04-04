using Microsoft.AspNetCore.Mvc;

namespace Resume.MVC.Controllers
{
    public class WorksController : SiteBaseController
    {
        public IActionResult Index()
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView();
            }
            return View();
        }
    }
}
