﻿using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
	public class CarController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult AddCar()
		{
			return View();
		}
	}
}