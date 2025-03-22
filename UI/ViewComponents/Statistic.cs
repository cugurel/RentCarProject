using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UI.Models;
using UI.Models.Identity;

namespace UI.ViewComponents
{
    public class Statistic:ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public Statistic(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        Context c = new Context();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var startOfNextMonth = startOfMonth.AddMonths(1);

            StatisticInfo statistic = new StatisticInfo();

            statistic.CountOfRent = c.Rents.Count(r => r.StartDate >= startOfMonth && r.StartDate < startOfNextMonth);

            statistic.CountOfCar = c.Cars.Count();
            statistic.CountOfC<ategory = c.Styles.Count();
            statistic.CountOfUser = _userManager.Users.Count();
            statistic.CountOfCustomer = c.Customers.Count();
            return View(statistic);
        }
    }
}
