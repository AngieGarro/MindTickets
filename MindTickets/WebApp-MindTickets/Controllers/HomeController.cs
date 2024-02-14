using DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using WebApp_MindTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using QRCoder;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Data;
using Microsoft.Data.SqlClient;
using DataAccess.Mapper;
using WebApp_MindTickets.Services;
using WebApp_MindTickets.Models.ViewModels;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace WebApp_MindTickets.Controllers
{
	public class HomeController : Controller
	{
		AuthMapper _mapper;
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult LandingPageDevMinds()
		{
			return View();
		}

        //[Authorize]
        public IActionResult HomePage()
		{
			return View();
		}

        public async Task<IActionResult> Logout()
		{

            // Delete cookies
            Response.Cookies.Delete("UserJson");
            Response.Cookies.Delete("MembershipJson");
            // Add more cookies to delete if needed
            //CONFIGURACION DE LA AUTENTICACION
            #region AUTENTICACTION
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            #endregion
            ViewBag.LoginOn = false;
			return RedirectToAction("Index", "Home");
		}
		public IActionResult Privacy()
		{
			return View();
		}
		public IActionResult Register()
		{
			return View();
		}

		public IActionResult RestartPassword()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		public ActionResult GenerateQRCode()
		{
			return View();
		}

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        // GET: Inicio
        public async Task<IActionResult> Login(User user)
		{
            if (user != null)
            {
                // Configuración de la autenticación
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim("Correo", user.Email),
        };

                if (!string.IsNullOrEmpty(user.UserType))
                {
                    var userRoles = user.UserType.Split(','); // Dividir la cadena en roles individuales

                    foreach (string rol in userRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, rol.Trim())); // Agregar cada rol
                    }
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                return View();
            }
        }

		public IActionResult Memberships()
		{
			return View();
		}

		public ActionResult Authenticated()
		{
			return View();
		}

		public ActionResult Restablecer()
		{
			return View();
		}

        public ActionResult Actualizar(string token)
		{
			ViewBag.Token = token;
			return View();
		}

        public ActionResult CheckOut()
        {
            return View();
        }

        public ActionResult AllEvents()
        {
            return View();
        }

        public ActionResult CheckOutTicket()
        {
            return View();
        }

		public ActionResult EventsAllLanding()
		{
			return View();
		}
	}
}

