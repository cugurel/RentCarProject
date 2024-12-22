using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
	public class CarController : Controller
	{
		Context c = new Context();
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
			var values = c.Cars.ToList(); //Linq sorgusu = select * from Cars
            return View(values);
        }
    }
}
