using DataAccessLayer.Concrete.EfRepository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class CustomerController : Controller
    {
        EfCustomerRepository customerRepository = new EfCustomerRepository();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

		[HttpPost]
		public IActionResult AddCustomer(Customer customer)
		{
            customerRepository.AddCustomer(customer);
            return RedirectToAction("List", "Customer");
		}

		public IActionResult List()
        {
			var values = customerRepository.GetAll();
			return View(values);
		}
    }
}
