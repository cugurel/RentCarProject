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

        public IActionResult List()
        {
			var rentList = _rentService.GetAll();
            return View(rentList);
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

        public IActionResult DeleteRent(int id)
        {
            var values = _rentService.GetById(id);
            _rentService.Delete(values);
            return RedirectToAction("List","Rent");
        }


        [HttpGet]
        public IActionResult UpdateRent(int id)
        {
            var value = _rentService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateRent(Rent rent)
        {
            _rentService.Update(rent);
            return RedirectToAction("List", "Rent");
        }
    }
}
