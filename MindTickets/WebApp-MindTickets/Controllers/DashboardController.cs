using Microsoft.AspNetCore.Mvc;

namespace WebApp_MindTickets.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
