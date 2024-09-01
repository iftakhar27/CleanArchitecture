﻿using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers
{
	public class VillaController : Controller
	{
		private readonly ApplicationDbContext _db;

        public VillaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
		{
			var villasList = _db.Villas.ToList();
			return View(villasList);
		}
		public IActionResult Create()
		{
			return View();
		}
	}
}
