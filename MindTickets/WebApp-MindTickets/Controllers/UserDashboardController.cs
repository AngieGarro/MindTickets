using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_MindTickets.Controllers
{
    public class UserDashboardController : Controller
    {
        //[Authorize(Roles = "Cliente")]
        public IActionResult Perfil()
        {
            return View();
        }

        public IActionResult Dashboard() 
        {
            return View();
        }

        public IActionResult MyEvents() {
            return View();
        }

        public IActionResult EventHistory()
        {
            return View();
        }

        public IActionResult Reports() 
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult TemplateTickets()
        {
            return View();
        }

    }
}
