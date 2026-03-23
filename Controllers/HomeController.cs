using Microsoft.AspNetCore.Mvc;

namespace Projet2_M.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Dashboard");
        }
    }
}