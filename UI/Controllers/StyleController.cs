using DataAccessLayer.Concrete.EfRepository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UI.Controllers
{
	public class StyleController : Controller
	{
		EfStyleRepository styleRepository = new EfStyleRepository();

		string apiUrl = "https://localhost:7133/api/Category/";
		HttpClient client = new HttpClient();
		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> List()
		{
			var result = await client.GetAsync(apiUrl + "GetAllCategories");

			var jsonString = result.Content.ReadAsStringAsync().Result;
			var styles = JsonConvert.DeserializeObject<List<Style>>(jsonString);
			return View(styles);
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
