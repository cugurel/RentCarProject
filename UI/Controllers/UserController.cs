using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UI.Models.Identity;

namespace UI.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        UserManager<User> _userManager;
        SignInManager<User> _signingManager;
        RoleManager<IdentityRole> _roleManager;

		
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signingManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var user = await _userManager.FindByIdAsync(userId);
            return View(user);
        }

        public IActionResult List()
        {
            var users = _userManager.Users.Where(x => x.Status == true).ToList();
            return View(users);
        }

        public IActionResult UnApprovedUserList()
        {
            var users = _userManager.Users.Where(x=>x.Status==false).ToList();
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
                return RedirectToAction("List", "User");
            }
			return RedirectToAction("List", "User");
		}

        public async Task<IActionResult> ApproveUser(string id)
        {
            
            var user = await _userManager.FindByIdAsync(id);

            user.Status = true;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                TempData["SuccessRegister"] = "Kayıt başarılı!";
                return RedirectToAction("List", "User");
            }
            return RedirectToAction("List", "User");
        }
    }
}
