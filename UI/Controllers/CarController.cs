using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EfRepository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{

	
	public class CarController : Controller
	{
		EfCarRepository repository = new EfCarRepository();
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
			repository.AddCar(car);
            return RedirectToAction("List", "Car");
        }
		[Authorize]
		public IActionResult List()
        {
			var values = repository.GetAll();
            return View(values);
        }

        public IActionResult DeleteCar(int id)
        {
            var value = repository.GetById(id);
			repository.DeleteCar(value);
			return RedirectToAction("List", "Car");
        }

		[HttpGet]
		public IActionResult UpdateCar(int Id)
		{
			var value = repository.GetById(Id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateCar(Car car)
		{
			repository.UpdateCar(car);
			return RedirectToAction("List", "Car");
		}
	}
}
