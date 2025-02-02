using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EfRepository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
	public class CarController : Controller
	{
		ICarService _carService;

		public CarController(ICarService carService)
		{
			_carService = carService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult AddCar()
		{
			return View();
		}

        [HttpPost]
        public IActionResult AddCar(Car car)
        {
			_carService.Add(car);
            return RedirectToAction("List", "Car");
        }
		[Authorize]
		public IActionResult List()
        {
			var values = _carService.GetAll();
            return View(values);
        }

        public IActionResult DeleteCar(int id)
        {
            var value = _carService.GetById(id);
			_carService.Delete(value);
			return RedirectToAction("List", "Car");
        }

		[HttpGet]
		public IActionResult UpdateCar(int Id)
		{
			var value = _carService.GetById(Id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateCar(Car car)
		{
			_carService.Update(car);
			return RedirectToAction("List", "Car");
		}
	}
}
