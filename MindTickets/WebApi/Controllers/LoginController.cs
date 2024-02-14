using Core.Managers;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{

		[HttpGet]
		[Route("RetrieveByEmail")]
		public async Task<IActionResult> RetrieveByEmail(string correo)
		{
			var user = new User();
			var ism = new LoginManager();
			user = ism.retrieveByEmail(correo);
			return Ok(user);
		}

		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login(string correo, string clave)
		{
			var ism = new LoginManager();
			var InicioDiccionario = new List<Dictionary<string, object>>();

			//Envia correo y password mediante um.login y trae informacion de BD
			InicioDiccionario = ism.InicioSesion(correo, clave);

			if (InicioDiccionario.Count > 0)
			{
				//Sacar informacion del diccionario para comparar y validar acceso 
				var user = new User();
				//user.Id = Convert.ToInt32(InicioDiccionario[0]["Id"]);
				user.Email = InicioDiccionario[0]["Email"]?.ToString();
				user.Password = InicioDiccionario[0]["Password"]?.ToString();

				
					if (clave.Equals(user.Password))
							{
								return Ok("Bienvenido");
							}
							else
							{

								return Ok("Clave incorrecta");
							}
				}
			return Ok(InicioDiccionario);
		}
	}
}