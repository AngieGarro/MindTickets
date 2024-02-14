using Microsoft.AspNetCore.Mvc;

namespace WebApp_MindTickets.Controllers
{
    public class ValuesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
