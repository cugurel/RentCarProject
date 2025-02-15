using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UI.Models.Identity;

namespace UI.Controllers
{
    public class UserController : Controller
    {
        UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> AddUser(RegisterModel model)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			var user = new User
			{
				FirstName = model.Firstname,
				LastName = model.Surname,
				Email = model.Email,
				PhoneNumber = model.Phone,
				UserName = model.Username
			};


			var userWithEmail = await _userManager.FindByEmailAsync(user.Email);

			if (userWithEmail != null)
			{
				TempData["EmailError"] = "Bu email hesabı ile zaten bir kullanıcı var";
				return View();
			}

			var result = await _userManager.CreateAsync(user, model.Password);

			if (result.Succeeded)
			{
				TempData["SuccessRegister"] = "Kayıt başarılı!";
				return RedirectToAction("Login", "Auth");
			}
			return View();
		}
	}
}
