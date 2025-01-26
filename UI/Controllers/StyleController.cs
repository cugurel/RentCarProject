using DataAccessLayer.Concrete.EfRepository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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

        public async Task<IActionResult> DeleteStyle(int Id)
        {
			var result = await client.DeleteAsync(apiUrl + "DeleteById/" + Id);
			if (result.IsSuccessStatusCode)
			{
				return RedirectToAction("List","Style");
			}

			return View();
        }

		[HttpGet]
		public IActionResult AddStyle() 
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> AddStyle(Style style)
        {
			var jsonStyle = JsonConvert.SerializeObject(style);
			StringContent content = new StringContent(jsonStyle, Encoding.UTF8,"application/json");
			var result = await client.PostAsync(apiUrl + "AddCategory", content);
			if (result.IsSuccessStatusCode)
			{
				return RedirectToAction("List", "Style");
			}
			return View();
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
