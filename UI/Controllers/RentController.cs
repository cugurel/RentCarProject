using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
	public class RentController : Controller
	{
		IRentService _rentService;

        public RentController(IRentService rentService)
        {
            _rentService = rentService;
        }

        public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult AddRent()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddRent(Rent rent)
		{
			_rentService.Add(rent);
			return View();
		}
	}
}
