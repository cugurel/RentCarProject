using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EfRepository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		EfStyleRepository repository = new EfStyleRepository();

		[HttpGet("GetAllCategories")]
		public IActionResult GetAll()
		{
			var value = repository.GetAll();
			return Ok(value);
		}

		[HttpGet("GetById/{id}")]
		public IActionResult GetById(int id)
		{
			var value = repository.GetById(id);
			return Ok(value);
		}

		[HttpPost("AddCategory")]
		public IActionResult AddCategory(Style style)
		{
			repository.AddStyle(style);
			return Ok(style);
		}

		[HttpDelete("DeleteById/{id}")]
		public IActionResult DeleteById(int id)
		{
			var value = repository.GetById(id);
			repository.DeleteStyle(value);
			return Ok("Veri silindi");
		}

		[HttpPut("UpdateCategory")]
		public IActionResult UpdateCategory(Style style)
		{
			repository.UpdateStyle(style);
			return Ok(style);
		}
	}
}
