using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhiteLagoon.Domain.Entities;
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

        [HttpPost]
        public IActionResult Create(Villa villa)
        {
            if (villa.Name == villa.Description)
            {
                ModelState.AddModelError("name", "The description cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Villas.Add(villa);
                _db.SaveChanges();
                TempData["success"] = "The villa has been created successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int villaId)
        {
            var villaDetails = _db.Villas.Where(x => x.Id == villaId).FirstOrDefault();
            if (villaDetails != null)
            {
                return View(villaDetails);
            }
            return RedirectToAction("Error", "Home");

        }

        [HttpPost]
        public IActionResult Update(Villa villa)
        {
            if (ModelState.IsValid && villa.Id > 0)
            {
                _db.Villas.Update(villa);
                _db.SaveChanges();
                TempData["success"] = "The villa has been updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int villaId)
        {
            Villa? obj = _db.Villas.Where(x => x.Id == villaId).FirstOrDefault();
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }


        [HttpPost]
        public IActionResult Delete(Villa obj)
        {
            var villaObj = _db.Villas.Where(_ => _.Id == obj.Id).FirstOrDefault();
            if (villaObj is not null)
            {
                _db.Villas.Remove(villaObj);
                _db.SaveChanges();
                TempData["success"] = "The villa has been deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["error"] = "Failed to delete the villa.";
            }
            return View();
        }
    }
}
