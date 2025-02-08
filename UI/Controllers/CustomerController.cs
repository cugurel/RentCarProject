using BusinessLayer.Abstract;
using DataAccessLayer.Concrete.EfRepository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

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
            _customerService.Add(customer);
            return RedirectToAction("List", "Customer");
		}

		public IActionResult List()
        {
			var values = _customerService.GetAll();
			return View(values);
		}


        [HttpGet]
        public IActionResult UpdateCustomer(int Id)
        {
            var value = _customerService.GetById(Id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _customerService.Update(customer);
            return RedirectToAction("List", "Customer");
        }
    }
}
