using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_MindTickets.Controllers
{
    //[Authorize(Roles = "Administrador")]
    public class AdminDashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Membership() {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult User()
        {
            return View();
        }

        public IActionResult Administration() {
            return View();
        }

        public IActionResult Events()
        {
            return View();
        }

        public IActionResult AProfile()
        {
            return View();
        }

        public IActionResult UnderMaintenance()
        {
            return View();
        }
    }
}
