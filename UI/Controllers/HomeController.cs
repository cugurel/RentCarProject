using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PartList()
        {
            return View();
        }
    }
}