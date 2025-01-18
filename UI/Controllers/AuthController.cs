using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UI.Models.Identity;

namespace UI.Controllers
{
	public class AuthController : Controller
	{
		UserManager<User> _userManager;
		SignInManager<User> _signinManager;

		public AuthController(UserManager<User> userManager, SignInManager<User> signinManager)
		{
			_userManager = userManager;
			_signinManager = signinManager;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(LoginModel model)
		{
			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterModel model)
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

			if(userWithEmail != null)
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
