using Microsoft.AspNetCore.Mvc;
using Resume.MVC.Models;
using System.Diagnostics;

namespace Resume.MVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return RedirectToAction("Index", "AboutMe");
        }
    }
}
