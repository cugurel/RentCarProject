using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EfRepository;
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
	}
}
