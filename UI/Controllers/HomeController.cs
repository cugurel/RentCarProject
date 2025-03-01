using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        IRentService _rentService;

        public HomeController(IRentService rentService)
        {
            _rentService = rentService;
        }
        public IActionResult Index()
        {
            var rentList = _rentService.GetAll();
            return View(rentList);
        }

        public IActionResult PartList()
        {
            return View();
        }
    }
}
