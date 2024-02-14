using Microsoft.AspNetCore.Mvc;
using Core.Managers;
using DTOs;
using Microsoft.AspNetCore.Identity;
using DataAccess.Mapper;
using System.Web.Providers.Entities;
using User = DTOs.User;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : Controller
	{
        //RESTABLECER CLAVE:
		[HttpPut]
		[Route("ProcessPWS")]
		public async Task<IActionResult> ProcessPWS(string pwrd, string email)
		{
			try
			{
				var cm = new AuthManager();
				cm.ProcessPswrd(pwrd,email);
				return Ok("Password Update");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}

        //VALIDA TOKEN:
        [HttpPost]
        [Route("ValidateToken")]
        public async Task<IActionResult> ValidateToken(string userToken)
        {
            var cm = new AuthManager();
            var Dic = new List<Dictionary<string, object>>();
            Dic = cm.GetOTP(userToken);
            try
            {
                cm.ValidateToken(userToken);
				if (Dic.Count > 0)
				{

					var user = new User();
					user.Token = Dic[0]["CodeOTP"]?.ToString();

					if (userToken.Equals(user.Token))
					{
						return Ok("User authenticated");
					}
					else
					{
						return Ok("Token incorrecta");
					}
				}
				
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
			return Ok(Dic);
		}
		
		//GENRAR EMAIL CLAVE:
		[HttpPost]
		[Route("GenerateEmail")]
		public async Task<IActionResult> GenerateEmail(string email)
		{
			try
			{
				var cm = new AuthManager();
				cm.GeneratePswrd(email);
				return Ok(email);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

        //RESTABLECER CLAVE:
        [HttpPut]
        [Route("PasswordReset")]
        public async Task<IActionResult> PasswordReset(string pwrd, string email)
        {
            try
            {
                var cm = new AuthManager();
                cm.PasswordReset(pwrd, email);
                return Ok("Password Update");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
