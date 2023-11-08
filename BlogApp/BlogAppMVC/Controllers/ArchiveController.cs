using Microsoft.AspNetCore.Mvc;

namespace BlogAppMVC.Controllers
{
    public class ArchiveController : Controller
    {
        public IActionResult YearlyArchive()
        {
            return View();
        }
        public IActionResult MonthlyArchive()
        {
            return View();
        }
    }
}
