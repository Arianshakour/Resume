using Microsoft.AspNetCore.Mvc;

namespace Resume.MVC.Controllers
{
    public class ResumeController : SiteBaseController
    {
        [HttpGet("/resume")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
