using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EfRepository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Controllers
{
	public class CarController : Controller
	{
		ICarService _carService;
        Context c = new Context();
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
			

			List<SelectListItem> styleList = (from x in c.Styles.ToList()
											  select new SelectListItem
											  {
												  Text = x.Type + " " + x.TypeName,
												  Value = x.Id.ToString(),
											  }).ToList();

			ViewBag.StyleList = styleList;
			return View();
		}

        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            List<SelectListItem> styleList = (from x in c.Styles.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Type + " " + x.TypeName,
                                                  Value = x.Id.ToString(),
                                              }).ToList();

            ViewBag.StyleList = styleList;

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
            List<SelectListItem> styleList = (from x in c.Styles.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Type + " " + x.TypeName,
                                                  Value = x.Id.ToString(),
                                              }).ToList();

            ViewBag.StyleList = styleList;
            var value = _carService.GetById(Id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateCar(Car car)
		{
            List<SelectListItem> styleList = (from x in c.Styles.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Type + " " + x.TypeName,
                                                  Value = x.Id.ToString(),
                                              }).ToList();

            ViewBag.StyleList = styleList;
            _carService.Update(car);
			return RedirectToAction("List", "Car");
		}
	}
}
