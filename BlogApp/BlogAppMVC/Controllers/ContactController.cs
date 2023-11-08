using Microsoft.AspNetCore.Mvc;

namespace Neon.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}