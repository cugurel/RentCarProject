using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EfRepository;
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

		public IActionResult AddCar()
		{
			return View();
		}

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
    }
}
