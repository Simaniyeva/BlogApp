using Microsoft.AspNetCore.Mvc;

namespace BlogAppMVC.Controllers
{
    public class MemberShipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
