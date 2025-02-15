using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;
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
		public async Task<IActionResult> Login(LoginModel model)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			var user = await _userManager.FindByEmailAsync(model.Email);

			if(user == null)
			{
				TempData["LoginError"] = "Bu email ile bir kullanıcı bulunamadı";
				return View();
			}

			var result = await _signinManager.PasswordSignInAsync(user, model.Password, false, false);
			if (result.Succeeded)
			{
				return RedirectToAction("List", "Car");
			}
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
			model.Status = false;
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
				UserName = model.Username,
				Status = model.Status
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

		public async Task<IActionResult> Logout()
		{
			_signinManager.SignOutAsync();
			return RedirectToAction("Login", "Auth");
		}
	}
}
