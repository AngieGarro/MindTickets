using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Humanizer;
using WebApp_MindTickets.Models;

namespace WebApp_MindTickets.Controllers
{
    public class QRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }   

}
