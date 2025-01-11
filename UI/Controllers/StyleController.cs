using DataAccessLayer.Concrete.EfRepository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
	public class StyleController : Controller
	{
		EfStyleRepository styleRepository = new EfStyleRepository();
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult List()
		{
			var values = styleRepository.GetAll();
			return View(values);
		}

        public IActionResult DeleteStyle(int Id)
        {
            var value = styleRepository.GetById(Id);
			styleRepository.DeleteStyle(value);
			return RedirectToAction("List", "Style");
        }

		[HttpGet]
		public IActionResult AddStyle() 
		{
			return View();
		}

        [HttpPost]
        public IActionResult AddStyle(Style style)
        {
			styleRepository.AddStyle(style);
			return RedirectToAction("List", "Style");
        }

		[HttpGet]
		public IActionResult UpdateStyle(int id)
		{
			var value = styleRepository.GetById(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateStyle(Style style)
		{
			styleRepository.UpdateStyle(style);
			return RedirectToAction("List", "Style");
		}
	}
}
