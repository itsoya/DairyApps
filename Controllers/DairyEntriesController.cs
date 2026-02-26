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
        public IActionResult Create(DiaryEntry entry)
        {
            if (ModelState.IsValid)
            {
                _db.DiaryEntries.Add(entry);
                _db.SaveChanges();
                return RedirectToAction("Index", "DairyEntries");
            }
            return View(entry);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var entry = _db.DiaryEntries.Find(id);
            if (entry != null)
            {
                _db.DiaryEntries.Remove(entry);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "DairyEntries");
        }
        [HttpPut]
        public IActionResult Update(int id, DiaryEntry updatedEntry)
        {
            var entry = _db.DiaryEntries.Find(id);
            if (entry != null)
            {
                entry.Title = updatedEntry.Title;
                entry.Content = updatedEntry.Content;
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "DairyEntries");
        }
    }
}
