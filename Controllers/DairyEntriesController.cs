using DairyApp.Data;
using DairyApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DairyApp.Controllers
{
    public class DairyEntriesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DairyEntriesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<DiaryEntry> entries = _db.DiaryEntries.ToList();
            return View(entries);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DiaryEntry obj)
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title must be at least 3 characters long.");
            }

            if (ModelState.IsValid)
            {
                _db.DiaryEntries.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "DairyEntries");
            }

            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            return View(obj);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entry = _db.DiaryEntries.Find(id);
            if (entry == null || entry.Id != id)
            {
                return NotFound();
            }
            if (entry != null)
            {
                return View(entry);
            }
            return RedirectToAction("Index", "DairyEntries");
        }

        [HttpPost]
        public IActionResult Edit(DiaryEntry obj)
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title must be at least 3 characters long.");
            }

            if (ModelState.IsValid)
            {
                _db.DiaryEntries.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "DairyEntries");
            }

            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entry = _db.DiaryEntries.Find(id);
            if (entry == null || entry.Id != id)
            {
                return NotFound();
            }
            if (entry != null)
            {
                return View(entry);
            }
            return RedirectToAction("Index", "DairyEntries");
        }

        [HttpPost]
        public IActionResult Delete(DiaryEntry obj)
        {
            var entry = _db.DiaryEntries.Find(obj.Id);
            if (entry == null)
            {
                return NotFound();
            }
            _db.DiaryEntries.Remove(entry);
            _db.SaveChanges();
            return RedirectToAction("Index", "DairyEntries");
        }
    }
}
