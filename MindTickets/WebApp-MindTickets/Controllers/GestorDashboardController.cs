using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_MindTickets.Controllers
{
    //[Authorize(Roles = "Gestor")]
    public class GestorDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PerfilGestor()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Events() 
        {
            return View();
        }

        public IActionResult GProfile()
        {
            return View();
        }

        public IActionResult FinanceReport()
        {
            return View();
        }
		public IActionResult CreateEvent()
		{
			return View();
		}

        public IActionResult CreateEvents()
        {
            return View();
        }

		public IActionResult RetrieveAllEvents()
		{
			return View();
		}
		public IActionResult SelectEvent()
		{
			return View();
		}
		public IActionResult StageSeat()
		{
			return View();
		}
	}
}
