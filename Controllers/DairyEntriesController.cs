using Microsoft.AspNetCore.Mvc;

namespace DairyApp.Controllers
{
    public class DairyEntriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
