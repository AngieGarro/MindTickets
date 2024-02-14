using Microsoft.AspNetCore.Mvc;

namespace WebApp_MindTickets.Controllers
{
    public class MembershipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
