﻿using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AddCustomer()
        {
            return View();
        }
    }
}
