using Microsoft.AspNetCore.Mvc;

namespace WebApp_MindTickets.Controllers
{
    public class GoogleMapsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Map()
        {
            return View();
        }
    }
}
