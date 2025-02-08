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
    }
}
